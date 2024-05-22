using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paineis.Application.DTOs;
using Paineis.Application.Interfaces;
using Paineis.Domain.Interfaces;

namespace Paineis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
        {
            _UsuarioRepository = usuarioRepository;
            _UsuarioService = usuarioService;
        }

        [HttpGet("selecionarTodos")]
        [Authorize]
        public async Task<ActionResult> GetUsuarios()
        {
            var UsuarioDTO = await _UsuarioService.SelecionarTodosAsync();

            if (UsuarioDTO == null)
            {
                return BadRequest("Ocorreu um erro");
            }

            return Ok(UsuarioDTO);
        }


        [HttpPost("Insert")]
        [Authorize]
        public async Task<ActionResult> Cadastrar(UsuarioDTO grupoAd)
        {

            var UsuarioDTO = await _UsuarioService.Incluir(grupoAd);

            if (UsuarioDTO == null)
            {
                return BadRequest("Ocorreu um erro no insert");
            }

            return Ok(UsuarioDTO);
        }


        /* [HttpGet("selecionarTodos")]
         public async Task<ActionResult<IEnumerable<TGrupoAd>>> GetUsuarios()
         {
             return Ok(await _UsuarioRepository.SelecionarTodosAsync());
         }

         [HttpGet("selecionarTodos/{id}")]
         public async Task<ActionResult<IEnumerable<TGrupoAd>>> GetUsuariosUnic(int id)
         {
             return Ok(await _UsuarioRepository.SelecionarAsync(id));
         }


         [HttpPost("Insert")]
         public async Task<ActionResult> Cadastrar(TGrupoAd grupoAd)
         {
             await _UsuarioRepository.Incluir(grupoAd);
             return Ok("Resultado ok");

         }


         [HttpPut("Update")]
         public async Task<ActionResult> Update(TGrupoAd grupoAd)
         {
             await _UsuarioRepository.Alterar(grupoAd);
             return Ok("Atualizou");
         }


         [HttpDelete("delete/{id}")]
         public async Task<ActionResult> Delete(int id)
         {
             await _UsuarioRepository.Excluir(id);
             return Ok("Deletou");
         }*/
    }
}
