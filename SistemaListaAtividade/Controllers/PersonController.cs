using Microsoft.AspNetCore.Mvc;
using SistemaListaAtividade.Application.Services.General;
using SistemaListaAtividade.Domain.Entities;
using SistemaListaAtividade.Domain.Entities.Dto;

namespace SistemaListaAtividade.Controllers
{
    [ApiController]
    [Route("api/v1/person")]
    public class PersonController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public PersonController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            var result = await _serviceUoW.PersonService.AddPerson(person);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonDto personDto)
        {
            Person updatePerson = await _serviceUoW.PersonService.UpdatePerson(personDto);
            return Ok(updatePerson);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _serviceUoW.PersonService.DeletePersonAsync(id);
            return Ok();
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPerson()
        {
            var persons = await _serviceUoW.PersonService.GetAllPersons();
            return Ok(persons);
        }

        [HttpGet("{firstName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPersonByFirstName(string firstName)
        {
            var persons = await _serviceUoW.PersonService.GetAllPersonByFirstName(firstName);
            return Ok(persons);
        }
    }
}