using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IPerfilRepository
    {
        Task<TPerfil[]> Incluir(TPerfil Perfil);
        Task<TPerfil[]> Alterar(TPerfil Perfil);
        Task<TPerfil[]> Excluir(int CodigoPerfil);
        Task<TPerfil> SelecionarAsync(int CodigoPerfil);
        Task<IEnumerable<TPerfil>> SelecionarTodosAsync();
    }
}
