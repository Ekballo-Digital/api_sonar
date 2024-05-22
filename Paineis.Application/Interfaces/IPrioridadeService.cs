using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IPrioridadeService
    {
        Task<PrioridadeDTO[]> Incluir(PrioridadeDTO Prio);
        Task<PrioridadeUpDTO[]> Alterar(PrioridadeUpDTO Prio);
        Task<PrioridadeDTO[]> Excluir(int CodigoPrioridade);
        Task<PrioridadeDTO> SelecionarAsync(int CodigoPrioridade);
        Task<IEnumerable<PrioridadeDTO>> SelecionarTodosAsync();
    }
}
