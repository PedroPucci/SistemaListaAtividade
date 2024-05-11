using System.ComponentModel;

namespace SistemaListaAtividade.Domain.Enums.Errors
{
    public enum PracticeErrors
    {
        [Description("'Name' can not be null or empty!")]
        Practice_Error_NameCanNotBeNullOrEmpty,

        [Description("'Description' can not be null or empty!")]
        Practice_Error_DescriptionCanNotBeNullOrEmpty
    }
}