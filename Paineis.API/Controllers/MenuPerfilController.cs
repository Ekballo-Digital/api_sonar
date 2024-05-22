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
    public class MenuPerfilController : Controller
    {

        private readonly IMenuPerfilService _menuPerfilService;

        public MenuPerfilController(IMenuPerfilService menuPerfilService)
        {
            _menuPerfilService = menuPerfilService;
        }

        [HttpPost("InsertMenuPerfil")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(MenuPerfiDTO menPer)
        {

            var MenuPerDTO = await _menuPerfilService.Incluir(menPer);

            if (MenuPerDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(MenuPerDTO);

        }

        /*[HttpPut("UpdateMenuPerfil")]
        public async Task<ActionResult> Update(MenuPerfiDTO menPer)
        {

            var MenuPerDTO = await _menuPerfilService.Alterar(menPer);

            if (MenuPerDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(MenuPerDTO);

        }*/

        [HttpDelete("DeleteMenuPerfil/{CodigoMenu}/{CodigoPerfil}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int CodigoMenu, int CodigoPerfil)
        {
            try
            {
                await _menuPerfilService.Excluir(CodigoMenu, CodigoPerfil);
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

        [HttpGet("SelectMenuPerfil")]
        [Authorize]
        public async Task<ActionResult> SelectAlerta()
        {

            var menuDTO = await _menuPerfilService.SelecionarTodosAsync();

            if (menuDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(menuDTO);

        }
    }
}
