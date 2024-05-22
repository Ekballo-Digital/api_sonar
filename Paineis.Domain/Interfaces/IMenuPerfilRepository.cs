using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IMenuPerfilRepository
    {
        Task<TMenuPerfil[]> Incluir(TMenuPerfil MenuPerfil);
        //Task<TMenuPerfil[]> Alterar(TMenuPerfil MenuPerfil);
        Task<TMenuPerfil> Excluir(int CodigoPerfil,int CodigoMenu);
        Task<TMenuPerfil> SelecionarAsync(int CodigoPerfil, int CodigoMenu);
        Task<IEnumerable<TMenuPerfil>> SelecionarTodosAsync();
    }
}
