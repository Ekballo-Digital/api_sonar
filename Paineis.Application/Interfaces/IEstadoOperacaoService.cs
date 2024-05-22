using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IEstadoOperacaoService
    {
        Task<TEstadoDTO[]> Incluir(TEstadoDTO Estado);
        Task<TEstadoUpTDO[]> Alterar(TEstadoUpTDO Estado);
        Task<TEstadoDTO[]> Excluir(int CodigoEstado);
        Task<TEstadoDTO> SelecionarAsync(int CodigoEstado);
        Task<IEnumerable<TEstadoUpTDO>> SelecionarTodosAsync();
    }
}
