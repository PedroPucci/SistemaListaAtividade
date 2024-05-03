using Microsoft.AspNetCore.Mvc;
using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class PersonController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public PersonController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            var result = await _serviceUoW.PersonService.AddPerson(person);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdatePerson([FromBody] Person person)
        {
            try
            {
                Person updatePerson = await _serviceUoW.PersonService.UpdatePerson(person);
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

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPersons()
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
    }
}