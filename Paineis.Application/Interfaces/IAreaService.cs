using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IAreaService
    {
        Task<AreaDTO[]> Incluir(AreaDTO Area);
        Task<AreaUpDTO[]> Alterar(AreaUpDTO Area);
        Task<AreaDTO[]> Excluir(int CodigoArea);
        Task<AreaDTO> SelecionarAsync(int CodigoArea);
        Task<IEnumerable<AreaUpDTO>> SelecionarTodosAsync();
    }
}
