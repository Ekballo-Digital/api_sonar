using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paineis.API.Models;
using Paineis.Application.DTOs;
using Paineis.Domain.Interfaces;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class LogController : Controller
    {
        private readonly ILogRepository _logRepository;

        public LogController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        [HttpPost("LogMensagem")]
        [Authorize]
        public async Task<ActionResult> LogMensagem(LogMensagem log)
        {

           var logDTO = await _logRepository.LogEnvioMsg(log.DataMsg, log.MatriculaUsuarioMsg, log.CodigoEstadoMsg, log.DescricaoMsg, log.CodigoAreaMsg, log.CodigoStatusEnvioMsg);

            if (logDTO == null)
            {
                return Ok();
            }

            return BadRequest("Ocorreu um erro no insert");
        }

        [HttpPost("LogOperacao")]
        [Authorize]
        public async Task<ActionResult> LogOperacao(LogOperacao log)
        {

            var logDTO = await _logRepository.LogOperacao(log.DataLogOperacao, log.MatriculaUsuarioLogOperacao, log.CodigoPerfilLogOperacao, log.CodigoFuncaoLogOperacao, log.DescricaoLogOperacao, log.TipoQueryLogOperacao);

            if (logDTO == null)
            {
                return Ok();
            }

            return BadRequest("Ocorreu um erro no insert");
        }
    }
}
