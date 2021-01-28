using System;
using System.ComponentModel.DataAnnotations;

namespace StandByTest.Models {
    public class Cliente {
        public int Id { get; set; }
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Data de Fundação")]
        [DataType(DataType.Date)]
        public DateTime DataFundacao { get; set; }
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }
        [DataType(DataType.Currency)]
        public decimal Capital { get; set; }
        public bool Quarentena { get; set; }
        public bool Status { get; set; }
        [Display(Name = "Classificação")]
        public char Classificacao { get; set; }

        public bool IsNewCliente()
        {
            return Id == 0;
        }
    }
}
