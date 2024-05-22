using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IFuncaoMenuRepository
    {
        Task<TFuncaoMenu[]> Incluir(TFuncaoMenu FuncaoMenu);
        //Task<TFuncaoMenu> Alterar(TFuncaoMenu FuncaoMenu);
        Task<TFuncaoMenu> Excluir(int CodigoMenu, int CodigoFuncao);
        Task<TFuncaoMenu> SelecionarAsync(int CodigoMenu, int CodigoFuncao);
        Task<IEnumerable<TFuncaoMenu>> SelecionarTodosAsync();
    }
}
