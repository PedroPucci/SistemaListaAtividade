using SistemaListaAtividade.Domain.General;

namespace SistemaListaAtividade.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}