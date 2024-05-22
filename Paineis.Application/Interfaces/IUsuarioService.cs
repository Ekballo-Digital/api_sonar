using Paineis.Application.DTOs;

namespace Paineis.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Incluir(UsuarioDTO NomeGrupoAd);
        Task<UsuarioDTO> Alterar(UsuarioDTO NomeGrupoAd);
        Task<UsuarioDTO> Excluir(int CodigoGrupoAd);
        Task<UsuarioDTO> SelecionarAsync(int CodigoGrupoAd);
        Task<IEnumerable<UsuarioDTO>> SelecionarTodosAsync();
    }
}
