using Paineis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface IAlertaService
    {
        Task<AlertaDTO[]> Incluir(AlertaDTO Alerta);
        Task<AlertaUpDTO[]> Alterar(AlertaUpDTO Alerta);
        Task<AlertaDTO[]> Excluir(int CodigoAlerta);
        Task<AlertaDTO> SelecionarAsync(int CodigoAlerta);
        Task<IEnumerable<AlertaUpDTO>> SelecionarTodosAsync();
    }
}
