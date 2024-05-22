using Paineis.Domain.Entities;

namespace Paineis.Domain.Interfaces
{
    public interface ITgrupoAdRepository
    {
        Task<TGrupoAd[]> Incluir(TGrupoAd NomeGrupoAd);
        Task<TGrupoAd[]> Alterar(TGrupoAd NomeGrupoAd);
        Task<TGrupoAd[]> Excluir(int CodigoGrupoAd);
        Task<TGrupoAd> SelecionarAsync(int CodigoGrupoAd);
        Task<IEnumerable<TGrupoAd>> SelecionarTodosAsync();
    }
}
