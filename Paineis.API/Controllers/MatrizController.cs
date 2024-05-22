using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Application.Services;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class MatrizController : Controller
    {

        private readonly IMatrizService _matrizService;

        public MatrizController(IMatrizService matrizService)
        {
            _matrizService = matrizService;
        }

        [HttpPost("InsertMatriz")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(MatrizDTO var)
        {

            var matrizDTO = await _matrizService.Incluir(var);

            if (matrizDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(matrizDTO);

        }

        [HttpPut("UpdateMatriz")]
        [Authorize]
        public async Task<ActionResult> Update(TMatrizUpdateDTO var)
        {

            var matrizDTO = await _matrizService.Alterar(var);

            if (matrizDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(matrizDTO);

        }

        [HttpDelete("DeleteMatriz/{CodigoEstado}/{CodigoArea}/{CodigoAlerta}/{CodigoPrioridade}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int CodigoEstado, int CodigoArea, int CodigoAlerta, int CodigoPrioridade)
        {
            await _matrizService.Excluir(CodigoEstado, CodigoArea, CodigoAlerta, CodigoPrioridade);
            return Ok("Deletou");

        }

        [HttpGet("SelectMatriz")]
        [Authorize]
        public async Task<ActionResult> SelectMatriz()
        {

            var MenuDTO = await _matrizService.SelecionarTodosAsync();

            if (MenuDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(MenuDTO);

        }
    }
}
