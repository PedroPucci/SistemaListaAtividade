using FluentValidation;
using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Domain.Enums.Errors;
using SistemaListaAtividade.Domain.Helpers;

namespace SistemaListaAtividade.Domain.Validator
{
    public class PersonRequestValidator : AbstractValidator<Person>
    {
        public PersonRequestValidator() 
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage(PersonErrors.Person_Error_FirstNameCanNotBeNullOrEmpty.Description());

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage(PersonErrors.Person_Error_EmailCanNotBeNullOrEmpty.Description());

            RuleFor(p => p.Email)
                .ValidEmail()
                .WithMessage(PersonErrors.Person_Error_EmailInvalid.Description());
        }
    }
}