using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface ITabelaMatriz
    {

        Task<GerarSilgasTabelaMatrizEntities[]> GerarSilgasTabela();
        Task<GerarEstadosTabelaMatrizEntities[]> GerarEstadoTabela(int CodigoArea);
        Task<GerarAlertasTabelaMatrizEntities[]> GerarAlertasTabela(int CodigoEstado);
    }
}
