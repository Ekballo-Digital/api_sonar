using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface IFilaRepository
    {
        Task<int> FilaEnvio(List<AlertasEntitiesNovo[]> res, string matricula);
        Task<int> FilaEnvioUnico(List<AlertasEntitiesNovo> alertas, string matricula);
        Task<GruposMsg[]> FilaGrupos();
        Task<TFila[]> DeletaFila(int CodigoFilaMsg);
        Task<IEnumerable<TFila>> SelectFilaEnvio(string matricula, int PainelEnvio);
        Task<IEnumerable<TFila>> SelectFilaEnvioGeral(int CodigoPainel);
        Task<int> UpdateRespostaPainel(int CodigoArea, string Mensagem, int CodigoAlerta);
    }
}
