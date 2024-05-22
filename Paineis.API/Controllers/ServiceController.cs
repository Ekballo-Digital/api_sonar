using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paineis.Application.DTOs;
using Paineis.Infra.Ioc;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ServiceController : Controller
    {

        private readonly SocketServerPainelHostedService _socketService;

        public ServiceController(SocketServerPainelHostedService socketService)
        {
            _socketService = socketService;
        }

        [HttpPost("RestartService")]
        [Authorize]
        public async Task<ActionResult> RestartService()
        {
            var cts = new CancellationTokenSource();
            await _socketService.RestartAsync(cts.Token);

            return Ok();
        }
    }
}
