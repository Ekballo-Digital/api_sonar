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
    public class FuncaoSistemaController : Controller
    {
        private readonly IFuncaoSistemaService _funcaoSistemaService;

        public FuncaoSistemaController(IFuncaoSistemaService funcaoSistemaService)
        {
            _funcaoSistemaService = funcaoSistemaService;
        }

        [HttpPost("InsertFuncao")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(FuncaoDTO fun)
        {

            var FuncaoDTO = await _funcaoSistemaService.Incluir(fun);

            if (FuncaoDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(FuncaoDTO);

        }

        [HttpPut("UpdateFuncao")]
        [Authorize]
        public async Task<ActionResult> Update(FuncaoUpDTO fun)
        {

            var FuncaoDTO = await _funcaoSistemaService.Alterar(fun);

            if (FuncaoDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(FuncaoDTO);

        }

        [HttpDelete("DeleteFuncao/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            try
            {
                await _funcaoSistemaService.Excluir(cod);
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
                return StatusCode(500, "Erro ao excluir a função.");
            }

        }

        [HttpGet("SelectFuncao")]
        [Authorize]
        public async Task<ActionResult> SelectAlerta()
        {

            var DTO = await _funcaoSistemaService.SelecionarTodosAsync();

            if (DTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(DTO);

        }
    }
}
