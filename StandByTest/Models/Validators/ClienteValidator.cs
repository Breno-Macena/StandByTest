using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandByTest.Models.Validators {
    public class ClienteValidator: AbstractValidator<Cliente> {

        public ClienteValidator() {
            RuleFor(c => c.RazaoSocial)
                .NotEmpty().WithMessage("Campo obrigatório.");
            RuleFor(c => c.DataFundacao)
                .NotEmpty().WithMessage("Campo obrigatório.");
            RuleFor(c => c.Cnpj)
                .NotEmpty().WithMessage("Campo obrigatório.")
                .IsValidCNPJ().WithMessage("CNPJ inválido.");
            RuleFor(c => c.Capital)
                .NotEmpty().WithMessage("Campo obrigatório.");
        }

    }
}
