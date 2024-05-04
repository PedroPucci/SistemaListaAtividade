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

        public async Task<Practice> AddPractice(Practice practice)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                practice.ModificationDate = DateTime.UtcNow;
                var result = await _repositoryUoW.PracticeRepository.AddPracticeAsync(practice);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Practice> UpdatePractice(Practice practice)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                Practice practiceByName = await _repositoryUoW.PracticeRepository.GetPracticeByNameAsync(practice.Name);

                if (practiceByName == null)
                    throw new InvalidOperationException("Practice does not found!");

                practiceByName.Description = practice.Description;
                practiceByName.ModificationDate = DateTime.UtcNow;

                var result = _repositoryUoW.PracticeRepository.UpdatePracticeAsync(practiceByName);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task DeletePractice(int practiceId)
        {
            var practiceToDelete = await _repositoryUoW.PracticeRepository.GetPracticeByIdAsync(practiceId);

            if (practiceToDelete == null)
                throw new ArgumentException("Practice not found with the given ID.");

            _repositoryUoW.PracticeRepository.DeletePracticeAsync(practiceToDelete);
            await _repositoryUoW.SaveAsync();
        }

        public async Task<List<Practice>> GetAllPractices()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<Practice> practiceList = await _repositoryUoW.PracticeRepository.GetAllPracticesAsync();
                _repositoryUoW.Commit();
                return practiceList;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Practice> GetAllPracticeByFirstName(string name)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new InvalidOperationException("Name can not be empty or null!");

                string newName = char.ToUpper(name[0]) + name.Substring(1);

                Practice practice = await _repositoryUoW.PracticeRepository.GetPracticeByNameAsync(newName);

                if (practice == null)
                    throw new InvalidOperationException("Practice not found!");

                _repositoryUoW.Commit();
                return practice;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
            finally
            {
                transaction.Dispose();
            }
        }
    }
}