using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Persistence.Repository.Interfaces
{
    public interface IPracticeRepository
    {
        Task<Practice> AddPracticeAsync(Practice practice);
        Practice UpdatePractice(Practice practice);
        Task<List<Practice>> GetAllPracticesAsync();
    }
}