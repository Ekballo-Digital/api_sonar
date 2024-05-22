using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IMatrizRepository
    {
        Task<TMatriz[]> Incluir(TMatriz Matriz);
        Task<TMatrizUpdate[]> Alterar(TMatrizUpdate Matriz);
        Task<TMatriz> Excluir(int CodigoEstado, int CodigoArea, int CodigoAlerta, int CodigoPrioridade);
        Task<TMatriz> SelecionarAsync(int CodigoEstado, int CodigoArea);
        Task<IEnumerable<TMatriz>> SelecionarTodosAsync();
    }
}
