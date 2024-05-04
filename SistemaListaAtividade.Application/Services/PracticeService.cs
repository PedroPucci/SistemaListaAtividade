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
                throw new InvalidOperationException("An error occurred while adding the Practice! " + ex + "");
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
                practiceByName.Type = practice.Type;
                practiceByName.ModificationDate = DateTime.UtcNow;

                var result = _repositoryUoW.PracticeRepository.UpdatePracticeAsync(practiceByName);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred while updating the Practice! " + ex + "");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task DeletePractice(int practiceId)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var practiceToDelete = await _repositoryUoW.PracticeRepository.GetPracticeByIdAsync(practiceId);

                if (practiceToDelete == null)
                    throw new ArgumentException("Practice not found with the given ID.");

                _repositoryUoW.PracticeRepository.DeletePracticeAsync(practiceToDelete);
                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred while removing the Practice! " + ex + "");
            }
            finally
            {
                transaction.Dispose();
            }            
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
                throw new InvalidOperationException("An error occurred while loading the Practices! " + ex + "");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Practice> GetAllPracticeByName(string name)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new InvalidOperationException("Name can not be empty or null!");
                
                Practice practice = await _repositoryUoW.PracticeRepository.GetPracticeByNameAsync(name);

                if (practice == null)
                    throw new InvalidOperationException("Practice not found!");

                _repositoryUoW.Commit();
                return practice;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred while loading the Practice! " + ex + "");
            }
            finally
            {
                transaction.Dispose();
            }
        }
    }
}