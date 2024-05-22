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
    public class EstadoController : Controller
    {
        private readonly IEstadoOperacaoService _estadoOperacaoService;

        public EstadoController(IEstadoOperacaoService estadoOperacaoService)
        {
            _estadoOperacaoService = estadoOperacaoService;
        }

        [HttpPost("InsertEstado")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(TEstadoDTO estado)
        {

            var EstadoDTO = await _estadoOperacaoService.Incluir(estado);

            if (EstadoDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(EstadoDTO);

        }

        [HttpPut("UpdateEstado")]
        [Authorize]
        public async Task<ActionResult> Update(TEstadoUpTDO estado)
        {

            var EstadoDTO = await _estadoOperacaoService.Alterar(estado);

            if (EstadoDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(EstadoDTO);

        }

        [HttpDelete("DeleteEstado/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            try
            {
                await _estadoOperacaoService.Excluir(cod);
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


        [HttpGet("SelectEstado")]
        [Authorize]
        public async Task<ActionResult> SelectEstado()
        {

            var EstadoDTO = await _estadoOperacaoService.SelecionarTodosAsync();

            if (EstadoDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(EstadoDTO);

        }
    }
}
