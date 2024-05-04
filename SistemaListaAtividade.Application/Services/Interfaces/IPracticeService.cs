using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Application.Services.Interfaces
{
    public interface IPracticeService
    {
        Task<Result<Practice>> AddPractice(Practice practice);
        Task<Practice> UpdatePractice(Practice practice);
        Task DeletePractice(int practiceId);
        Task<List<Practice>> GetAllPractices();
        Task<Practice> GetAllPracticeByName(string name);
    }
}