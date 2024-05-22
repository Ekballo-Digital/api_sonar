using Paineis.Application.DTOs;
using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IFilaService
    {
        Task<FilaDTO[]> Excluir(int CodigoFilaMsg);
        Task<IEnumerable<FilaDTO>> SelectFilaEnvio(string matricula, int CodigoPainel);
        Task<IEnumerable<FilaDTO>> SelectFilaEnvioGeral(int CodigoPainel);
    }
}
