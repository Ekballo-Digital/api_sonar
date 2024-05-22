using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paineis.API.Models;
using Paineis.Domain.Interfaces;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class EnviarMensagemController : Controller
    {
        private readonly IEnviarMensagem _iEnviarMensagem;

        public EnviarMensagemController(IEnviarMensagem iEnviarMensagem)
        {
            _iEnviarMensagem = iEnviarMensagem;
        }

        [HttpPost("GetEstado")]
        [Authorize]
        public async Task<IActionResult> GetEstado(PegaEstado body)
        {
            try
            {
                var var = await _iEnviarMensagem.PegaEstado(body.CodigoEstado);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAlerta")]
        [Authorize]
        public async Task<IActionResult> GetAlerta()
        {
            try
            {
                var var = await _iEnviarMensagem.PegaAlerta();
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAlerta2")]
        [Authorize]
        public async Task<IActionResult> GetAlerta2()
        {
            try
            {
                var var = await _iEnviarMensagem.PegaAlerta2();
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPropiedades")]
        [Authorize]
        public async Task<IActionResult> GetPropiedades()
        {
            try
            {
                var var = await _iEnviarMensagem.PegaPrioridade();
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
