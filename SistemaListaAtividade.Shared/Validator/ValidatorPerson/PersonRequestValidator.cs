using FluentValidation;
using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Domain.Enums.Errors;
using SistemaListaAtividade.Domain.Helpers;
using SistemaListaAtividade.Shared.Validator.General;

namespace SistemaListaAtividade.Shared.Validator.ValidatorPerson
{
    public class PersonRequestValidator : AbstractValidator<Person>
    {
        public PersonRequestValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .MinimumLength(4)
                .WithMessage(PersonErrors.Person_Error_FirstNameCanNotBeNullOrEmpty.Description());

            /*
                Continue - This is the default behavior, which continues to invoke the validations even though a previous validation has failed.
                Stop - Stops executing validation checks as soon as the first validation breaks.
             */
            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(10)
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