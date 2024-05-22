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
    public class CorController : Controller
    {

        private readonly ICorService _corService;

        public CorController(ICorService corService)
        {
            _corService = corService;
        }

        [HttpPost("InsertCor")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(CorDTO cor)
        {

            var CorDTO = await _corService.Incluir(cor);

            if (CorDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(CorDTO);
           
        }

        [HttpPut("UpdateCor")]
        [Authorize]
        public async Task<ActionResult> Update(CorUpDTO cor)
        {

            var CorDTO = await _corService.Alterar(cor);

            if (CorDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(CorDTO);

        }

        [HttpDelete("DeleteCor/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {

            try
            {
                await _corService.Excluir(cod);
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

        [HttpGet("SelectCor")]
        [Authorize]
        public async Task<ActionResult> SelectCor()
        {

            var CorDTO = await _corService.SelecionarTodosAsync();

            if (CorDTO == null)
            {
                return BadRequest("Ocorreu um erro ");
            }

            return Ok(CorDTO);

        }
    }
}
