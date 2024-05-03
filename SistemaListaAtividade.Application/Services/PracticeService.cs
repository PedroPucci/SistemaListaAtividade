using SistemaListaAtividade.Application.Services.Interfaces;
using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Persistence.Repository.General;

namespace SistemaListaAtividade.Application.Services
{
    public class PracticeService : IPracticeService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public PracticeService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<Practice> AddPractice(Practice practice)
        {
            throw new NotImplementedException();
        }

        public Task<List<Practice>> GetAllPractices()
        {
            throw new NotImplementedException();
        }

        public Task<Practice> UpdatePractice(Practice practice)
        {
            throw new NotImplementedException();
        }
    }
}