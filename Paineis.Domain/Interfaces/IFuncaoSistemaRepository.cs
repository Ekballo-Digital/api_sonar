using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IFuncaoSistemaRepository
    {
        Task<TFuncao[]> Incluir(TFuncao Funcao);
        Task<TFuncao[]> Alterar(TFuncao Funcao);
        Task<TFuncao> Excluir(int CodigoFuncao);
        Task<TFuncao> SelecionarAsync(int CodigoFuncao);
        Task<IEnumerable<TFuncao>> SelecionarTodosAsync();
    }
}
