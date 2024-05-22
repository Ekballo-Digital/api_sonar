using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IPainelRepository
    {
        Task<TPainel[]> Incluir(TPainel Painel);
        Task<TPainel[]> Alterar(TPainel Painel);
        Task<TPainel[]> Excluir(int CodigoPainel);
        Task<TPainel> SelecionarAsync(int CodigoPainel);
        Task<TPainel> SelecionarIpPort(int CodigoArea);
        Task<TCorSocket[]> SelecionarCorPainel(int CodigoAlerta);
        Task<IEnumerable<TFila>> SelecionarFilaPainel();
        Task<IEnumerable<TFila>> SelecionarFilaPainelGrupo(int grupo);
        Task<IEnumerable<TPainel>> SelecionarTodosAsync();
    }
}
