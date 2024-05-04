using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Application.Services.Interfaces
{
    public interface IPracticeService
    {
        Task<Practice> AddPractice(Practice practice);
        Task<Practice> UpdatePractice(Practice practice);
        Task DeletePractice(int practiceId);
        Task<List<Practice>> GetAllPractices();
        Task<Practice> GetAllPracticeByFirstName(string name);
    }
}