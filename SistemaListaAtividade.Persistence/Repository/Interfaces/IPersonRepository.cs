using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Persistence.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> AddPersonAsync(Person person);
        Person UpdatePersonAsync(Person person);
        Person DeletePersonAsync(Person personToDelete);
        Task<List<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByNameAsync(string? personName);
        Task<Person> GetPersonByIdAsync(int? id);
    }
}