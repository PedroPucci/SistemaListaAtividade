using SistemaListaAtividade.Application.Services.Interfaces;
using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Persistence.Repository.Interfaces;

namespace SistemaListaAtividade.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public PersonService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<Person> AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}