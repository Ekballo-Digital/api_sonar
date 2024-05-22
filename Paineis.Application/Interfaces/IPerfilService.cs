using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IPerfilService
    {
        Task<PerfilDTO[]> Incluir(PerfilDTO Perfil);
        Task<PerfilUpDTO[]> Alterar(PerfilUpDTO Perfil);
        Task<PerfilDTO[]> Excluir(int CodigoPerfil);
        Task<PerfilDTO> SelecionarAsync(int CodigoPerfil);
        Task<IEnumerable<PerfilUpDTO>> SelecionarTodosAsync();
    }
}
