using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IMatrizService
    {
        Task<MatrizDTO[]> Incluir(MatrizDTO Matriz);
        Task<TMatrizUpdateDTO[]> Alterar(TMatrizUpdateDTO Matriz);
        Task<MatrizDTO> Excluir(int CodigoEstado, int CodigoArea, int CodigoAlerta, int CodigoPrioridade);
        Task<MatrizDTO> SelecionarAsync(int CodigoEstado, int CodigoArea);
        Task<IEnumerable<MatrizDTO>> SelecionarTodosAsync();
    }
}
