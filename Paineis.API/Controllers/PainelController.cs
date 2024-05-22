using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class PainelController : Controller
    {
        private readonly IPainelService _painelService;

        public PainelController(IPainelService painelService)
        {
            _painelService = painelService;
        }

        [HttpPost("InsertPainel")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(PainelDTO painel)
        {

            var PainelDTO = await _painelService.Incluir(painel);

            if (PainelDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(PainelDTO);

        }

        [HttpPut("UpdatePainel")]
        [Authorize]
        public async Task<ActionResult> Update(PainelUpDTO painel)
        {

            var PainelDTO = await _painelService.Alterar(painel);

            if (PainelDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(PainelDTO);

        }

        [HttpDelete("DeletePainel/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            try
            {
                await _painelService.Excluir(cod);
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

        [HttpGet("SelectPainel")]
        [Authorize]
        public async Task<ActionResult> SelectPainel()
        {

            var PainelDTO = await _painelService.SelecionarTodosAsync();

            if (PainelDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(PainelDTO);

        }

        [HttpGet("SelectPainelUso/{CodPainel}")]
        [Authorize]
        public async Task<ActionResult> SelectPainelUso(int CodPainel)
        {

            var PainelDTO = await _painelService.SelecionarAsync(CodPainel);

            if (PainelDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(PainelDTO);

        }
    }
}
