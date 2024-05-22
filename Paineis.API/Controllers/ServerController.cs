using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paineis.API.Models;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Domain.Interfaces;
using Paineis.Infra.Ioc;
using System.Net;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ServerController : Controller
    {

        private readonly ISocketServerPainelService _socketServerPainelService;

        public ServerController(ISocketServerPainelService socketServerPainelService)
        {
            _socketServerPainelService = socketServerPainelService;
        }

        [HttpPost("Sever")]
        [Authorize]
        public async Task<IActionResult> Server([FromBody] List<AlertasModelNovo> dados)
        {

            try
            {
                //List<AlertasModel> alertas = AlertasModel.DeserializeFromJson(dados);

                //var userId = User.GetPerfil();

                //Console.WriteLine(userId);

                //var usuario = User.GetPerfil();

                //Console.WriteLine("AQUIIII:" + usuario);

                var matricula = User.FindFirstValue("Matricula");

                var var = await _socketServerPainelService.EnvioGeral(dados, matricula);

                Console.WriteLine(var);

                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("ServerUnico")]
        [Authorize]
        public async Task<IActionResult> ServerUnico([FromBody] List<AlertasModelNovo> dados)
        {

            try
            {
                //List<AlertasModel> alertas = AlertasModel.DeserializeFromJson(dados);

                //var userId = User.GetPerfil();

                //Console.WriteLine(userId);

                //var usuario = User.GetPerfil();

                //Console.WriteLine("AQUIIII:" + usuario);

                var matricula = User.FindFirstValue("Matricula");

                var var = await _socketServerPainelService.EnvioGeralUnico(dados, matricula);

                Console.WriteLine(var);

                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Mute")]
        [Authorize]
        public async Task<IActionResult> Mute(Mute request)
        {

            try
            {
                await _socketServerPainelService.MutePainel(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("Teste")]
        [Authorize]
        public async Task<IActionResult> Teste(Mute request)
        {

            try
            {
                await _socketServerPainelService.EnvioTeste(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
