using Microsoft.AspNetCore.Mvc;
using SistemaListaAtividade.Application.Services.Interfaces;
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
            try
            {
                Person updatePerson = await _serviceUoW.PersonService.UpdatePerson(personDto);
                return Ok(new
                {
                    mensagem = $"Person registration updated successfully."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "An error occurred while updating the Person! " + ex + ""
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                await _serviceUoW.PersonService.DeletePersonAsync(id);
                return Ok(new
                {
                    mensagem = $"Person deleted successfully."
                });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new
                {
                    mensagem = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "An error occurred while deleting the Person! " + ex.Message
                });
            }
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPerson()
        {
            try
            {
                var persons = await _serviceUoW.PersonService.GetAllPersons();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading persons! " + ex + ""
                });
            }
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPersonByFirstName(string name)
        {
            try
            {
                var persons = await _serviceUoW.PersonService.GetAllPersonByFirstName(name);
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "There was an error loading persons! " + ex + ""
                });
            }
        }
    }
}