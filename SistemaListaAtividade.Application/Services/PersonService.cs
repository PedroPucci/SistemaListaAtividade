using SistemaListaAtividade.Application.Services.Interfaces;
using SistemaListaAtividade.Domain.Entities;
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

        public async Task<Person> AddPerson(Person person)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                person.ModificationDate = DateTime.UtcNow;
                var result = await _repositoryUoW.PersonRepository.AddPersonAsync(person);

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
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var personName = person.FirstName;

                Person personByName = await _repositoryUoW.PersonRepository.GetPersonByNameAsync(personName);

                if (personName == null)
                    throw new InvalidOperationException("Person does not found!");

                personByName.Email = person.Email;
                personByName.ModificationDate = DateTime.UtcNow;

                var result = _repositoryUoW.PersonRepository.UpdatePerson(personByName);

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
    }
}