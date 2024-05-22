using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Paineis.API.Models;
using Paineis.Application.DTOs;
using Paineis.Domain.Account;
using Paineis.Domain.Entities;
using Paineis.Infra.Ioc;
using System.Net.Http.Headers;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class LoginController : Controller
    {

        private readonly IAuthenticate _Authenticate;
        private readonly IGenerateMenu _GenerateMenu;
        private readonly IGeneratePainel _GeneratePainel;
        private readonly IAuthDoubleAd _AuthDoubleAd;
        private readonly IFuncaoMenuGenerate _FuncaoMenuGenerate;
        private readonly IPainelUso _PainelUso;

        public LoginController(IAuthenticate authenticate, IGenerateMenu generateMenu, IGeneratePainel generatePainel, IAuthDoubleAd authDoubleAd, IFuncaoMenuGenerate funcaoMenuGenerate, IPainelUso painelUso)
        {
            _Authenticate = authenticate;
            _GenerateMenu = generateMenu;
            _GeneratePainel = generatePainel;
            _AuthDoubleAd = authDoubleAd;
            _FuncaoMenuGenerate = funcaoMenuGenerate;
            _PainelUso = painelUso;
        }

        [HttpPost("Authentication")]
        public async Task<IActionResult> Authentication(Models.Auth auth)
        {
            var user = await _Authenticate.AuthenticateAsync(auth.MatriculaUsuario, auth.SenhaUsuario);

            /*switch (user[0].StatusCode)
            {
                case 401:
                    return BadRequest($"Senha ou matricula incorreta");

                case 203:
                    return Unauthorized($"Usuario {auth.MatriculaUsuario} não tem acesso ao sistema de paineis");

                case 300:
                    return Ok(user);

                default:
                    break;
            }*/

            return Ok(user);


        }

        [HttpPost("MenuGenerate")]
        [Authorize]
        public async Task<IActionResult> MenuGenerate(Models.GenerateMenu GenerateMenu)
        {

            try
            {
                /*var usuario = User.GetPerfil();

                if (usuario != 2)
                {
                     return Unauthorized("Você não tem permissão para realizar essa operação");
                }*/

                var var = await _GenerateMenu.GenerateMenuAsync(GenerateMenu.NomeGrupoAd);
                return Ok(var);
            }
            catch (Exception ex) {      
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PainelGenerate")]
        [Authorize]
        public async Task<IActionResult> PainelGenerate(Models.PainelGenerate PainelGenerate)
        {
            try
            {
                var var = await _GeneratePainel.GeneratePainelAsync(PainelGenerate.NomeGrupoAd);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AuthenticationDoubleAd")]
        [Authorize]
        public async Task<IActionResult> AuthenticationDoubleAd(Models.AuthDoubleAd AuthDoubleAd)
        {

            try
            {
                var var = await _AuthDoubleAd.AuthenticateDoubleAdAsync(AuthDoubleAd.NomeGrupoAd);
                return Ok(var);
            }
            catch (Exception ex)    
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("FuncaoMenuGenerate")]
        [Authorize]
        public async Task<IActionResult> FuncaoMenuGenerate(Models.FuncaoMenuGenerate FuncaoMenuGenerate)
        {

            try
            {
                var var = await _FuncaoMenuGenerate.FuncaoMenuGenerateAsync(FuncaoMenuGenerate.CodigoMenu);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("PainelUso")]
        [Authorize]
        public async Task<IActionResult> FuncaoPainelUso(Models.PainelUso painelUso)
        {
            try
            {
                var var = await _PainelUso.PegaPainelUso(painelUso.CodigoPainel);
                return Ok(var);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
