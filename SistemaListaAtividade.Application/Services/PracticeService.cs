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

        public async Task DeletePractice(int practiceId)
        {
            var practiceToDelete = await _repositoryUoW.PracticeRepository.GetPracticeByIdAsync(practiceId);

            if (practiceToDelete == null)
                throw new ArgumentException("Practice not found with the given ID.");

            _repositoryUoW.PracticeRepository.DeletePractice(practiceToDelete);
            await _repositoryUoW.SaveAsync();
        }
    }
}