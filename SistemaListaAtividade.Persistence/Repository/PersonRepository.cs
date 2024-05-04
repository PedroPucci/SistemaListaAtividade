using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Persistence.Connections;
using SistemaListaAtividade.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SistemaListaAtividade.Persistence.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Person> AddPersonAsync(Person person)
        {
            var result = await _context.Person.AddAsync(person);
            return result.Entity;
        }

        public Person UpdatePerson(Person person)
        {
            var response = _context.Person.Update(person);
            return response.Entity;
        }

        public Person DeletePerson(Person personToDelete)
        {
            _context.Practice.RemoveRange(personToDelete.Practices);
            var response = _context.Person.Remove(personToDelete);
            return response.Entity;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _context.Person
                .OrderBy(person => person.FirstName)
                .Select(person => new Person
            {
                FullName = person.FullName,                
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email
            }).ToListAsync();
        }        

        public async Task<Person> GetPersonByNameAsync(string? name)
        {
            return await _context.Person
                .Include(person => person.Practices)
                .FirstOrDefaultAsync(person => person.FirstName == name);
        }

        public async Task<Person> GetPersonByIdAsync(int? id)
        {
            return await _context.Person
                .Include(person => person.Practices)
                .FirstOrDefaultAsync(person => person.Id == id);
        }
    }
}