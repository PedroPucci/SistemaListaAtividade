using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Domain.Entities.Dto;

namespace SistemaListaAtividade.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Result<Person>> AddPerson(Person person);
        Task<Person> UpdatePerson(PersonDto personDto);
        Task DeletePersonAsync(int personId);
        Task<List<Person>> GetAllPersons();
        Task<Person> GetAllPersonByFirstName(string name);
    }
}