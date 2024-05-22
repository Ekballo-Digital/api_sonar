using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IMenuRepository
    {
        Task<TMenu[]> Incluir(TMenu Menu);
        Task<TMenu[]> Alterar(TMenu Menu);
        Task<TMenu> Excluir(int CodigoMenu);
        Task<TMenu> SelecionarAsync(int CodigoMenu);
        Task<IEnumerable<TMenu>> SelecionarTodosAsync();

    }
}
