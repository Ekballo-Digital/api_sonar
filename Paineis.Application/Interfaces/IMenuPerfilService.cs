using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IMenuPerfilService
    {
        Task<MenuPerfiDTO[]> Incluir(MenuPerfiDTO MenPer);
        //Task<MenuPerfiDTO[]> Alterar(MenuPerfiDTO MenPer);
        Task<MenuPerfiDTO> Excluir(int CodigoMenu, int CodigoPerfil);
        Task<MenuPerfiDTO> SelecionarAsync(int CodigoMenu, int CodigoPerfil);
        Task<IEnumerable<MenuPerfiDTO>> SelecionarTodosAsync();
    }
}
