using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IAreaRepository
    {
        Task<TArea[]> Incluir(TArea Area);
        Task<TArea[]> Alterar(TArea Area);
        Task<TArea[]> Excluir(int CodigoArea);
        Task<TArea> SelecionarAsync(int CodigoArea);
        Task<IEnumerable<TArea>> SelecionarTodosAsync();
    }
}
