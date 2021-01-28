using Microsoft.EntityFrameworkCore;
using StandByTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StandByTest.Database {
    public class ClienteRepository : IClienteRepository {
        private readonly StandByDbContext _context;

        public ClienteRepository(StandByDbContext context) {
            _context = context;
        }

        public async Task DeleteAsync(params Cliente[] obj) {
            _context.Clientes.RemoveRange(obj);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(params Cliente[] obj)
        {
            CheckIfClienteExists(obj);
            await _context.Clientes.AddRangeAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> FindAsync(Expression<Func<Cliente, bool>> filter = null) {
            if (filter == null)
                return await _context.Clientes.ToListAsync();
            return await _context.Clientes.Where(filter).ToListAsync();
        }

        public async Task<Cliente> FindAsync(int key) {
            return await _context.Clientes.FindAsync(key);
        }

        public async Task UpdateAsync(params Cliente[] obj) {
            CheckIfClienteExists(obj);
            _context.UpdateRange(obj);
            await _context.SaveChangesAsync();
        }

        private void CheckIfClienteExists(Cliente[] obj)
        {
            if (ClienteExists(obj))
                throw new Exception("Razão social e CNPJ já cadastrados.");
        }

        private bool ClienteExists(params Cliente[] obj)
        {
            foreach (var cliente in obj)
            {
                // verifica se já existe um cliente com o mesmo Cnpj e RazaoSocial no banco
                var c = _context.Clientes.AsNoTracking().Where(f => f.Cnpj == cliente.Cnpj && f.RazaoSocial == cliente.RazaoSocial).FirstOrDefault();
                if (c != null) // cliente já existe
                {
                    // se for um novo cadastro ou uma atualizacao de CNPJ e RazaoSocial que resulte em uma "colisão" com outro cliente, retorna true
                    if (cliente.IsNewCliente() || cliente.Id != c.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
