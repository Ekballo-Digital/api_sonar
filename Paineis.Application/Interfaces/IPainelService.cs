using Paineis.Application.DTOs;
using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IPainelService
    {
        Task<PainelDTO[]> Incluir(PainelDTO Painel);
        Task<PainelUpDTO[]> Alterar(PainelUpDTO Painel);
        Task<PainelDTO[]> Excluir(int CodigoPainel);
        Task<PainelDTO> SelecionarAsync(int CodigoPainel);
        Task<IEnumerable<PainelUpDTO>> SelecionarTodosAsync();
    }
}
