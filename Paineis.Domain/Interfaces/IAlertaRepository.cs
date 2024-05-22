using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IAlertaRepository
    {
        Task<TAlertum[]> Incluir(TAlertum Alerta);
        Task<TAlertum[]> Alterar(TAlertum Alerta);
        Task<TAlertum[]> Excluir(int CodigoAlerta);
        Task<TAlertum> SelecionarAsync(int CodigoAlerta);
        Task<IEnumerable<TAlertum>> SelecionarTodosAsync();
    }
}
