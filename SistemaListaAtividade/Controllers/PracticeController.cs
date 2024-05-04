using Microsoft.AspNetCore.Mvc;
using SistemaListaAtividade.Application.Services.General;

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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeletePractice(int id)
        {
            try
            {
                await _serviceUoW.PracticeService.DeletePractice(id);
                return Ok(new
                {
                    mensagem = $"Practice deleted successfully."
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
                    mensagem = "An error occurred while deleting the Practice! " + ex.Message
                });
            }
        }
    }
}