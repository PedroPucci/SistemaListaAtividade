﻿using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Domain.Entities.Dto;

namespace SistemaListaAtividade.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> AddPerson(Person person);
        Task<Person> UpdatePerson(PersonDto personDto);
        Task<List<Person>> GetAllPersons();
        Task<Person> GetAllPersonByFirstName(string name);
    }
}