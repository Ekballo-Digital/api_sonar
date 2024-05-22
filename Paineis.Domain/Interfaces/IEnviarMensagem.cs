using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IEnviarMensagem
    {
        Task<PegaEstado[]> PegaEstado(int CodigoEstado);

        Task<NivelAlerta[]> PegaAlerta();

        Task<NivelAlerta2[]> PegaAlerta2();

        Task<PegaPrioridade[]> PegaPrioridade();
    }
}
