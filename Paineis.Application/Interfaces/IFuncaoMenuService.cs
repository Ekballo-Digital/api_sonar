using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IFuncaoMenuService
    {
        Task<FuncaoMenuDTO[]> Incluir(FuncaoMenuDTO FuncMen);
        //Task<FuncaoMenuDTO[]> Alterar(FuncaoMenuDTO FuncMen);
        Task<FuncaoMenuDTO> Excluir(int CodigoMenu, int CodigoFuncao);
        Task<FuncaoMenuDTO> SelecionarAsync(int CodigoMenu, int CodigoFuncao);
        Task<IEnumerable<FuncaoMenuDTO>> SelecionarTodosAsync();
    }
}
