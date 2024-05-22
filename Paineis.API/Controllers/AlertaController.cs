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
    public class AlertaController : Controller
    {

        private readonly IAlertaService _alertaService;

        public AlertaController(IAlertaService alertaService)
        {
            _alertaService = alertaService;
        }


        [HttpPost("InsertAlerta")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(AlertaDTO alerta)
        {
            
            var AlertaDTO = await _alertaService.Incluir(alerta);

            if (AlertaDTO == null)
            {
              return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(AlertaDTO);
            
        }

        [HttpPut("UpdateAlerta")]
        [Authorize]
        public async Task<ActionResult> Update(AlertaUpDTO alerta)
        {

            var AlertaDTO = await _alertaService.Alterar(alerta);

            if (AlertaDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(AlertaDTO);

        }

        [HttpDelete("DeleteAlerta/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            try
            {
                await _alertaService.Excluir(cod);
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


        [HttpGet("SelectAlerta")]
        [Authorize]
        public async Task<ActionResult> SelectAlerta()
        {

            var AlertaDTO = await _alertaService.SelecionarTodosAsync();

            if (AlertaDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(AlertaDTO);

        }
    }
}
