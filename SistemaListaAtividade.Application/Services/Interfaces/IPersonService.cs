using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> AddPerson(Person person);
        Task<Person> UpdatePerson(Person person);
        Task<List<Person>> GetAllPersons();
    }
}