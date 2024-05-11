using FluentValidation;
using System.Text.RegularExpressions;

namespace SistemaListaAtividade.Shared.Validator.General
{
    public static class ValidatorsUtils
    {
        public static IRuleBuilderOptions<T, string> ValidEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        => ruleBuilder.Must(document => document.IsValidEmail());

        public static bool IsValidEmail(this string email)
        {
            if (email is null)
                return false;

            if (Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                return true;

            return false;
        }
    }
}