using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Application.Services;
using Paineis.Domain.Interfaces;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpPost("InsertMenu")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(MenuDTO menu)
        {

            var MenuDTO = await _menuService.Incluir(menu);

            if (MenuDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(MenuDTO);

        }

        [HttpPut("UpdateMenu")]
        [Authorize]
        public async Task<ActionResult> Update(MenuUpDTO menu)
        {

            var MenuDTO = await _menuService.Alterar(menu);

            if (MenuDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(MenuDTO);

        }

        [HttpDelete("DeleteMenu/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            try
            {
                await _menuService.Excluir(cod);
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

        [HttpGet("SelectMenu")]
        [Authorize]
        public async Task<ActionResult> SelectAlerta()
        {

            var MenuDTO = await _menuService.SelecionarTodosAsync();

            if (MenuDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(MenuDTO);

        }
    }
}
