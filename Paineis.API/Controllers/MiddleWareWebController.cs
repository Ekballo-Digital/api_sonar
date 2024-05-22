using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paineis.API.Models;
using Paineis.Domain.Account;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class MiddleWareWebController : Controller
    {

        private readonly IMiddleWareWeb _iMiddleWareWeb;

        public MiddleWareWebController(IMiddleWareWeb iMiddleWareWeb)
        {
            _iMiddleWareWeb = iMiddleWareWeb;
        }

        [HttpPost("ValidaPainel")]
        [Authorize]
        public async Task<ActionResult> ValidaPainel(ValidaWebPainel res)
        {
            var user = await _iMiddleWareWeb.ValidaPainelUsuario(res.CodigoPainel, res.NomeGrupoAd);

            return Ok(user);
        }


        [HttpPost("ValidaUrls")]
        [Authorize]
        public async Task<ActionResult> ValidaUrls(ValidaWebUrl res)
        {
            var user = await _iMiddleWareWeb.ValidaUrls(res.NomeGrupoAd, res.url);

            return Ok(user);
        }
    }
}
