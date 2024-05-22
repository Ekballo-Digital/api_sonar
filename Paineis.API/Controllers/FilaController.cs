using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Paineis.Application.Interfaces;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class FilaController : Controller
    {

        private readonly IFilaService _filaService;

        public FilaController(IFilaService service)
        {
            _filaService = service;
        }

        [HttpDelete("DeleteFila/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            
             try
             {
                await _filaService.Excluir(cod);
                return Ok("Deletou");
             }
             catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
             {
                            // Exceção de chave estrangeira do SQL Server
                Console.WriteLine($"Foreign key violation: {sqlEx.Message}");
                return StatusCode(500, "Erro ao excluir a Cor devido a uma violação de chave estrangeira.");
             }
             catch (Exception ex)
             {
                            // Outras exceções
                Console.WriteLine($"An error occurred while deleting: {ex.Message}");
                return StatusCode(500, "Erro ao excluir o alerta.");
             }
          
        }


        [HttpGet("SelectFilaEnvio/{matricula}/{PainelEnvio}")]
        [Authorize]
        public async Task<ActionResult> SelectFilaEnvio(string matricula, int PainelEnvio)
        {

            var DTO = await _filaService.SelectFilaEnvio(matricula, PainelEnvio);

            if (DTO == null)
            {
                return BadRequest("Ocorreu um erro ");
            }

            return Ok(DTO);

        }

        [HttpGet("SelectFilaEnvioGeral/{CodigoPainel}")]
        [Authorize]
        public async Task<ActionResult> SelectFilaEnvioGeral(int CodigoPainel)
        {

            var DTO = await _filaService.SelectFilaEnvioGeral(CodigoPainel);

            if (DTO == null)
            {
                return BadRequest("Ocorreu um erro ");
            }

            return Ok(DTO);

        }
    }
}
