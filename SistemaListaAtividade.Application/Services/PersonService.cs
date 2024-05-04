using SistemaListaAtividade.Application.Services.Interfaces;
using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Domain.Entities.Dto;
using SistemaListaAtividade.Domain.Validator;
using SistemaListaAtividade.Persistence.Repository.General;

namespace SistemaListaAtividade.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public PersonService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Result<Person>> AddPerson(Person person)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var isValidPerson = await IsValidPersonRequest(person);
                
                if (!isValidPerson.Success)
                    return Result<Person>.Error(isValidPerson.Message);

                person.ModificationDate = DateTime.UtcNow;
                var result = await _repositoryUoW.PersonRepository.AddPersonAsync(person);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();

                return Result<Person>.Ok();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred while adding the Person! " + ex + "");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Person> UpdatePerson(PersonDto personDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var personName = personDto.FirstName;

                Person personByName = await _repositoryUoW.PersonRepository.GetPersonByNameAsync(personName);

                if (personName == null)
                    throw new InvalidOperationException("Person does not found!");

                personByName.Email = personDto.Email;
                personByName.ModificationDate = DateTime.UtcNow;

                var result = _repositoryUoW.PersonRepository.UpdatePersonAsync(personByName);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred while updating the Person! " + ex + "");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task DeletePersonAsync(int personId)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var personToDelete = await _repositoryUoW.PersonRepository.GetPersonByIdAsync(personId);

                if (personToDelete == null)
                    throw new ArgumentException("Person not found with the given ID.");

                _repositoryUoW.PersonRepository.DeletePersonAsync(personToDelete);
                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred while removing the Person! " + ex + "");
            }
            finally
            {
                transaction.Dispose();
            }            
        }

        public async Task<List<Person>> GetAllPersons()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<Person> personList = await _repositoryUoW.PersonRepository.GetAllPersonsAsync();
                _repositoryUoW.Commit();
                return personList;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("There was an error loading persons! " + ex + "");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Person> GetAllPersonByFirstName(string name)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new InvalidOperationException("Name can not be empty or null!");

                string newName = char.ToUpper(name[0]) + name.Substring(1);

                Person person = await _repositoryUoW.PersonRepository.GetPersonByNameAsync(newName);

                if (person == null)
                    throw new InvalidOperationException("Person not found!");

                _repositoryUoW.Commit();
                return person;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("There was an error loading person! " + ex + "");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        private async Task<Result<Person>> IsValidPersonRequest(Person person)
        {
            var requestValidator = await new PersonRequestValidator().ValidateAsync(person);
            if (!requestValidator.IsValid)
            {
                string errorMessage = string.Join(" ", requestValidator.Errors.Select(e => e.ErrorMessage));
                errorMessage = errorMessage.Replace(Environment.NewLine, "");
                return Result<Person>.Error(errorMessage);
            }

            return Result<Person>.Ok();
        }
    }
}