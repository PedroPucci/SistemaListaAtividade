using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Persistence.Repository.Interfaces
{
    public interface IPracticeRepository
    {
        Task<Practice> AddPracticeAsync(Practice practice);
        Practice UpdatePractice(Practice practice);
        Practice DeletePractice(Practice practiceToDelete);
        Task<List<Practice>> GetAllPracticesAsync();
        Task<Practice> GetPracticeByIdAsync(int? id);
    }
}