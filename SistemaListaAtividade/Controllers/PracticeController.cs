using Microsoft.AspNetCore.Mvc;
using SistemaListaAtividade.Application.Services.General;
using SistemaListaAtividade.Domain.Entities.Dto;
using SistemaListaAtividade.Domain.Entities;

namespace SistemaListaAtividade.Controllers
{
    [ApiController]
    [Route("api/v1/practice")]
    public class PracticeController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public PracticeController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPractice([FromBody] Practice practice)
        {
            var result = await _serviceUoW.PracticeService.AddPractice(practice);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdatePractice([FromBody] Practice practice)
        {
            Practice updatePractice = await _serviceUoW.PracticeService.UpdatePractice(practice);
            return Ok(updatePractice);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeletePractice(int id)
        {
            await _serviceUoW.PracticeService.DeletePractice(id);
            return Ok();
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Practice>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPractice()
        {
            var practices = await _serviceUoW.PracticeService.GetAllPractices();
            return Ok(practices);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Practice>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPracticeByName(string name)
        {
            var practices = await _serviceUoW.PracticeService.GetAllPracticeByName(name);
            return Ok(practices);
        }
    }
}