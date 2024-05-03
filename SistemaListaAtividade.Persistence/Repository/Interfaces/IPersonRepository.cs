using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Persistence.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> AddPersonAsync(Person person);
        Person UpdatePerson(Person person);
        Task<List<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByNameAsync(string? personName);
    }
}