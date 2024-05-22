using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task<TLogEnvioMsg[]> LogEnvioMsg(DateTime DataMsg, string MatriculaUsuarioMsg, int CodigoEstadoMsg, string DescricaoMsg, int CodigoAreaMsg, int CodigoStatusEnvioMsg);
        Task<TLogOperacao[]> LogOperacao(DateTime DataLogOperacao, string MatriculaUsuarioLogOperacao, int CodigoPerfilLogOperacao, int CodigoFuncaoLogOperacao, string DescricaoLogOperacao, string TipoQueryLogOperacao);
    }
}
