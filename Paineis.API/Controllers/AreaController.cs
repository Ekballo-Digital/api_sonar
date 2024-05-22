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
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpPost("InsertArea")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(AreaDTO Area)
        {

            var AreaDTO = await _areaService.Incluir(Area);

            if (AreaDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(AreaDTO);

        }

        [HttpPut("UpdateArea")]
        [Authorize]
        public async Task<ActionResult> Update(AreaUpDTO area)
        {

            var AreaDTO = await _areaService.Alterar(area);

            if (AreaDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(AreaDTO);

        }

        [HttpDelete("DeleteArea/{cod}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int cod)
        {
            try
            {
                await _areaService.Excluir(cod);
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

        [HttpGet("SelectArea")]
        [Authorize]
        public async Task<ActionResult> SelectArea()
        {

            var AreaDTO = await _areaService.SelecionarTodosAsync();

            if (AreaDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(AreaDTO);

        }
    }
}
