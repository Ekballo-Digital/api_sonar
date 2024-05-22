using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface ICorService
    {
        Task<CorDTO[]> Incluir(CorDTO Cor);
        Task<CorUpDTO[]> Alterar(CorUpDTO Cor);
        Task<CorDTO[]> Excluir(int CodigoCor);
        Task<CorDTO> SelecionarAsync(int CodigoCor);
        Task<IEnumerable<CorUpDTO>> SelecionarTodosAsync();

    }
}
