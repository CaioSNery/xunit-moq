
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MRicos.Domain.Accounts.Entities.ValueObjects;

namespace MRicos.Application.UseCases.Create
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .MinimumLength(Email.MinLength)
                .WithMessage($"O email deve ter no mínimo {Email.MinLength} caracteres.");

            RuleFor(x => x.Email)
                .MaximumLength(Email.MaxLength)
                .WithMessage($"O email deve ter no máximo {Email.MaxLength} caracteres.");


            RuleFor(x => x.Email)
            .Matches(Email.Pattern)
            .WithMessage("O email deve ser um endereço de email válido.");
        }
    }
}