using FluentValidation;
using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Domain.Enums.Errors;
using SistemaListaAtividade.Domain.Helpers;

namespace SistemaListaAtividade.Domain.Validator
{
    public class PracticeRequestValidator : AbstractValidator<Practice>
    {
        public PracticeRequestValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(PracticeErrors.Practice_Error_NameCanNotBeNullOrEmpty.Description());

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage(PracticeErrors.Practice_Error_DescriptionCanNotBeNullOrEmpty.Description());            
        }
    }
}