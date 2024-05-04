using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Persistence.Repository.Interfaces
{
    public interface IPracticeRepository
    {
        Task<Practice> AddPracticeAsync(Practice practice);
        Practice UpdatePracticeAsync(Practice practice);
        Practice DeletePracticeAsync(Practice practiceToDelete);
        Task<List<Practice>> GetAllPracticesAsync();
        Task<Practice> GetPracticeByIdAsync(int? id);
        Task<Practice> GetPracticeByNameAsync(string? name);
    }
}