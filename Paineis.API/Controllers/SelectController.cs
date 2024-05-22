using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paineis.Domain.Interfaces;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class SelectController : Controller
    {

        private readonly ISelect _select;

        public SelectController(ISelect select)
        {
            _select = select;
        }

        [HttpGet("GetCor")]
        [Authorize]
        public async Task<IActionResult> GetCor()
        {
            try
            {
                var var = await _select.GerarCor();
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetArea")]
        [Authorize]
        public async Task<IActionResult> GetAreaOrLocal()
        {
            try
            {
                var var = await _select.GerarArea();
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPerfil")]
        [Authorize]
        public async Task<IActionResult> GetPerfil()
        {
            try
            {
                var var = await _select.GerarPerfil();
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMenu")]
        [Authorize]
        public async Task<IActionResult> GetMenu()
        {
            try
            {
                var var = await _select.GerarMenu();
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEstado")]
        [Authorize]
        public async Task<IActionResult> GetEstado()
        {
            try
            {
                var var = await _select.GerarEstado();
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetNomeEstado/{cod}")]
        [Authorize]
        public async Task<IActionResult> GetNomeEstado(int cod)
        {
            try
            {
                var var = await _select.GetNomeEstado(cod);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetNomeArea/{cod}")]
        [Authorize]
        public async Task<IActionResult> GetNomeArea(int cod)
        {
            try
            {
                var var = await _select.GetNomeArea(cod);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetNomeAlerta/{cod}")]
        [Authorize]
        public async Task<IActionResult> GetNomeAlerta(int cod)
        {
            try
            {
                var var = await _select.GetNomeAlerta(cod);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetNomePrioridade/{cod}")]
        [Authorize]
        public async Task<IActionResult> GetNomePrioridade(int cod)
        {
            try
            {
                var var = await _select.GetNomePrioridade(cod);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
