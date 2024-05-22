using Paineis.Application.DTOs;
using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface ISocketServerPainelService
    {
        Task<AlertasModel[]> EnvioGeral(List<AlertasModelNovo> request, string matricula);
        Task<AlertasModel[]> EnvioGeralUnico(List<AlertasModelNovo> request, string matricula);
        Task<bool> MutePainel(Mute request);
        Task<bool> EnvioTeste(Mute request);
        Task StartSendingMessages(CancellationToken cancellationToken);
        Task<bool> CriaFila(List<AlertasModelNovo> request, string matricula);
        Task UpdateDate();
    }

}
