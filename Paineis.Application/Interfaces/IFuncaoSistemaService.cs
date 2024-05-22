using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IFuncaoSistemaService
    {
        Task<FuncaoDTO[]> Incluir(FuncaoDTO Funcao);
        Task<FuncaoUpDTO[]> Alterar(FuncaoUpDTO Funcao);
        Task<FuncaoUpDTO> Excluir(int CodigoFuncao);
        Task<FuncaoUpDTO> SelecionarAsync(int CodigoFuncao);
        Task<IEnumerable<FuncaoUpDTO>> SelecionarTodosAsync();
    }
}
