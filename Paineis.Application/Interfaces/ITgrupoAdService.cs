using Paineis.Application.DTOs;

namespace Paineis.Application.Interfaces
{
    public interface ITgrupoAdService
    {
        Task<TGrupoAdDTO[]> Incluir(TGrupoAdDTO NomeGrupoAd);
        Task<TGrupoAdUpDTO[]> Alterar(TGrupoAdUpDTO NomeGrupoAd);
        Task<TGrupoAdDTO[]> Excluir(int CodigoGrupoAd);
        Task<TGrupoAdDTO> SelecionarAsync(int CodigoGrupoAd);
        Task<IEnumerable<TGrupoAdUpDTO>> SelecionarTodosAsync();
    }
}
