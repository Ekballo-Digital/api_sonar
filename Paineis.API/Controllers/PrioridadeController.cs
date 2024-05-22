using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Application.Services;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class PrioridadeController : Controller
    {
        private readonly IPrioridadeService _prioridadeService;

        public PrioridadeController(IPrioridadeService prioridadeService)
        {
            _prioridadeService = prioridadeService;
        }

        [HttpPost("InsertPrioridade")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(PrioridadeDTO prio)
        {

            var PrioDTO = await _prioridadeService.Incluir(prio);

            if (PrioDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(PrioDTO);

        }

        [HttpPut("UpdatePrioridade")]
        [Authorize]
        public async Task<ActionResult> Update(PrioridadeUpDTO prio)
        {

            var PrioDTO = await _prioridadeService.Alterar(prio);

            if (PrioDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(PrioDTO);

        }

        [HttpDelete("DeletePrioridade/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            try
            {
                await _prioridadeService.Excluir(cod);
                return Ok("Deletou");
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
            {
                // Exceção de chave estrangeira do SQL Server
                Console.WriteLine($"Foreign key violation: {sqlEx.Message}");
                return StatusCode(500, "Erro ao excluir o alerta devido a uma violação de chave estrangeira.");
            }
            catch (Exception ex)
            {
                // Outras exceções
                Console.WriteLine($"An error occurred while deleting: {ex.Message}");
                return StatusCode(500, "Erro ao excluir o alerta.");
            }
        }


        [HttpGet("SelectPrio")]
        [Authorize]
        public async Task<ActionResult> SelectPrio()
        {

            var PrioDTO = await _prioridadeService.SelecionarTodosAsync();

            if (PrioDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(PrioDTO);

        }
    }
}
