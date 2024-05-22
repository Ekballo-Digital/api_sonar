using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IMenuService
    {
        Task<MenuDTO[]> Incluir(MenuDTO Menu);
        Task<MenuUpDTO[]> Alterar(MenuUpDTO Menu);
        Task<MenuDTO> Excluir(int CodigoMenu);
        Task<MenuDTO> SelecionarAsync(int CodigoMenu);
        Task<IEnumerable<MenuUpDTO>> SelecionarTodosAsync();
    }
}
