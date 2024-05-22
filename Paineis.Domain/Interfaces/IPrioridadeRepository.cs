using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IPrioridadeRepository
    {
        Task<TPrioridade[]> Incluir(TPrioridade Prio);
        Task<TPrioridade[]> Alterar(TPrioridade Prio);
        Task<TPrioridade> Excluir(int CodigoPrioridade);
        Task<TPrioridade> SelecionarAsync(int CodigoPrioridade);
        Task<IEnumerable<TPrioridade>> SelecionarTodosAsync();
    }
}
