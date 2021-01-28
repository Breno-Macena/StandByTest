using Microsoft.AspNetCore.Mvc;
using StandByTest.Database;
using StandByTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StandByTest.Controllers {
    public class ClientesController : Controller {
        private readonly IClienteRepository repository;

        public ClientesController(IClienteRepository repository) {
            this.repository = repository;
        }

        public  IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Clientes([FromForm] ClienteFilterViewModel model) {
            List<Cliente> clientes;
            if (model.EmptyModel())
            {
                clientes = await repository.FindAsync();
            }
            else
            {
                clientes = await repository.FindAsync(f =>
                    (f.Cnpj == model.Cnpj || string.IsNullOrWhiteSpace(model.Cnpj)) &&
                    (string.IsNullOrWhiteSpace(model.RazaoSocial)) || f.RazaoSocial.ToLower().Contains(model.RazaoSocial.ToLower()) &&
                    (f.Status == model.Status || model.Status == null)
                );
            }
                
            return PartialView(clientes);
        }

        public async Task<IActionResult> Create(int? id) {
            return View(await repository.FindAsync(id ?? 0));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente) {
            if (ModelState.IsValid) {
                try
                {
                    cliente.Quarentena = EmQuarentena(cliente);
                    cliente.Classificacao = SetClassificacao(cliente);

                    if (cliente.IsNewCliente())
                        await repository.InsertAsync(cliente);
                    else
                        await repository.UpdateAsync(cliente);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(cliente);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        private bool EmQuarentena(Cliente cliente)
        {
            return DateTime.Now.AddYears(-1).Date <= cliente.DataFundacao.Date;
        }

        private char SetClassificacao(Cliente cliente)
        {
            if (cliente.Capital <= 10_000)
                return 'C';
            else if (cliente.Capital > 10_000 && cliente.Capital <= 1_000_000)
                return 'B';
            else
                return 'A';
        }

        public async Task<IActionResult> Delete(int id) {
            var cliente = await repository.FindAsync(id);
            if (cliente == null) {
                return NotFound();
            }

            return PartialView(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var cliente = await repository.FindAsync(id);
            await repository.DeleteAsync(cliente);
            return RedirectToAction(nameof(Index));
        }

        public class ClienteFilterViewModel
        {
            [Display(Name = "Razão Social")]
            public string RazaoSocial { get; set; }
            [Display(Name = "CNPJ")]
            public string Cnpj { get; set; }
            public bool? Status { get; set; }

            public bool EmptyModel()
            {
                return string.IsNullOrWhiteSpace(RazaoSocial) && string.IsNullOrWhiteSpace(Cnpj) && Status == null;
            }
        }

    }
}
