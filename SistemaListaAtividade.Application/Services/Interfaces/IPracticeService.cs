using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Practice> AddPractice(Practice practice);
        Task<Practice> UpdatePractice(Practice practice);
        Task<List<Practice>> GetAllPractices();
    }
}