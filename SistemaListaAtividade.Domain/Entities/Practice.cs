using SistemaListaAtividade.Domain.General;

namespace SistemaListaAtividade.Domain.Entities
{
    public class Practice : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}