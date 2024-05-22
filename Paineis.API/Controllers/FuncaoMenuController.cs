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
    public class FuncaoMenuController : Controller
    {
        private readonly IFuncaoMenuService _funcaoMenuService;

        public FuncaoMenuController(IFuncaoMenuService funcaoMenuService)
        {
            _funcaoMenuService = funcaoMenuService;
        }

        [HttpPost("InsertFuncaoMenu")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(FuncaoMenuDTO var)
        {

            var FuncaoMenuDTO = await _funcaoMenuService.Incluir(var);

            if (FuncaoMenuDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(FuncaoMenuDTO);


        }

        /*[HttpPut("UpdateFuncaoMenu")]
        public async Task<ActionResult> Update(FuncaoMenuDTO var)
        {

            var FuncaoMenuDTO = await _funcaoMenuService.Alterar(var);

            if (FuncaoMenuDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(FuncaoMenuDTO);

        }*/

        [HttpDelete("DeleteFuncaoMenu/{CodigoMenu}/{CodigoFuncao}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int CodigoMenu, int CodigoFuncao)
        {
            try
            {
                await _funcaoMenuService.Excluir(CodigoMenu, CodigoFuncao);
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

        [HttpGet("SelectFuncaoMenu")]
        [Authorize]
        public async Task<ActionResult> SelectFuncaoMenu()
        {

            var menuDTO = await _funcaoMenuService.SelecionarTodosAsync();

            if (menuDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(menuDTO);

        }
    }
}
