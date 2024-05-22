using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IEstadoOperacaoRepository
    {
        Task<TEstado[]> Incluir(TEstado Estado);
        Task<TEstado[]> Alterar(TEstado Estado);
        Task<TEstado[]> Excluir(int CodigoEstado);
        Task<TEstado> SelecionarAsync(int CodigoEstado);
        Task<IEnumerable<TEstado>> SelecionarTodosAsync();
    }
}
