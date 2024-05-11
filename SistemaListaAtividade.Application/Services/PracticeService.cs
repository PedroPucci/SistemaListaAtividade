using Serilog;
using SistemaListaAtividade.Application.Services.Interfaces;
using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Persistence.Repository.General;
using SistemaListaAtividade.Shared.Validator.ValidatorPractice;

namespace SistemaListaAtividade.Application.Services
{
    public class PracticeService : IPracticeService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public PracticeService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Result<Practice>> AddPractice(Practice practice)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidPractice = await IsValidPracticeRequest(practice);

                if (!isValidPractice.Success)
                {
                    Log.Error("Message: Error invalid inputs");
                    return Result<Practice>.Error(isValidPractice.Message);
                }                    

                practice.ModificationDate = DateTime.UtcNow;
                var result = await _repositoryUoW.PracticeRepository.AddPracticeAsync(practice);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return Result<Practice>.Ok();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to add a new Practice " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
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
                {
                    Log.Error("Message: Practice does not found!");
                    throw new InvalidOperationException("Practice does not found!");
                }                   

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
                Log.Error("Message: Error to updating a Practice " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
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
                {
                    Log.Error("Practice not found with the given ID.");
                    throw new ArgumentException("Practice not found with the given ID.");
                }                    

                _repositoryUoW.PracticeRepository.DeletePracticeAsync(practiceToDelete);
                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to delete a Practice " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
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
                Log.Error("Message: Error to loading the list Practice " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
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
                {
                    Log.Error("Name can not be empty or null!");
                    throw new InvalidOperationException("Name can not be empty or null!");
                }                    
                
                Practice practice = await _repositoryUoW.PracticeRepository.GetPracticeByNameAsync(name);

                if (practice is null)
                {
                    Log.Error("Practice not found!");
                    throw new InvalidOperationException("Practice not found!");
                }                    

                _repositoryUoW.Commit();
                return practice;
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to loading a Practice " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private async Task<Result<Practice>> IsValidPracticeRequest(Practice practice)
        {
            var requestValidator = await new PracticeRequestValidator().ValidateAsync(practice);
            if (!requestValidator.IsValid)
            {
                string errorMessage = string.Join(" ", requestValidator.Errors.Select(e => e.ErrorMessage));
                errorMessage = errorMessage.Replace(Environment.NewLine, "");
                return Result<Practice>.Error(errorMessage);
            }

            return Result<Practice>.Ok();
        }
    }
}