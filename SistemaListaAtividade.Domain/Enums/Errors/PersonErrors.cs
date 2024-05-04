using System.ComponentModel;

namespace SistemaListaAtividade.Domain.Enums.Errors
{
    public enum PersonErrors
    {
        [Description("'FirstName' can not be null or empty!")]
        Person_Error_FirstNameCanNotBeNullOrEmpty,

        [Description("'Email' can not be null or empty!")]
        Person_Error_EmailCanNotBeNullOrEmpty,
    }
}