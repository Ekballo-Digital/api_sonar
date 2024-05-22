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
    public class PerfilController : Controller
    {

        private readonly IPerfilService _perfilService;

        public PerfilController(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpPost("InsertPerfil")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(PerfilDTO perfil)
        {

            var PerfilDTO = await _perfilService.Incluir(perfil);

            if (PerfilDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(PerfilDTO);

        }

        [HttpPut("UpdatePerfil")]
        [Authorize]
        public async Task<ActionResult> Update(PerfilUpDTO perfil)
        {

            var PerfilDTO = await _perfilService.Alterar(perfil);

            if (PerfilDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(PerfilDTO);

        }

        [HttpDelete("DeletePerfil/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            try
            {
                await _perfilService.Excluir(cod);
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

        [HttpGet("SelectPerfil")]
        [Authorize]
        public async Task<ActionResult> SelectPainel()
        {

            var DTO = await _perfilService.SelecionarTodosAsync();

            if (DTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(DTO);

        }
    }
}
