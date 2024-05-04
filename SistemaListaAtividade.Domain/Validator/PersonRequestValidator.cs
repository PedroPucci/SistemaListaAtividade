using FluentValidation;
using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Domain.Validator
{
    public class PersonRequestValidator : AbstractValidator<Person>
    {
        public PersonRequestValidator() 
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage("'FirstName' can not be null or empty!");

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("'Email' can not be null or empty!");
        }
    }
}