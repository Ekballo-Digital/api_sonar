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
    public class GrupoAdController : Controller
    {
        private readonly ITgrupoAdService _grupoAdService;

        public GrupoAdController(ITgrupoAdService grupoAdService)
        {
            _grupoAdService = grupoAdService;
        }

        [HttpPost("InsertAd")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(TGrupoAdDTO grupo)
        {

            var adDTO = await _grupoAdService.Incluir(grupo);

            if (adDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(adDTO);
        

        }

        [HttpPut("UpdateAd")]
        [Authorize]
        public async Task<ActionResult> Update(TGrupoAdUpDTO ad)
        {

            var adDTO = await _grupoAdService.Alterar(ad);

            if (adDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(adDTO);
    

        }

        [HttpDelete("DeleteAd/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            try
            {
                await _grupoAdService.Excluir(cod);
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

        [HttpGet("SelectAd")]
        [Authorize]
        public async Task<ActionResult> SelectAlerta()
        {

            var DTO = await _grupoAdService.SelecionarTodosAsync();

            if (DTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(DTO);

        }
    }
}
