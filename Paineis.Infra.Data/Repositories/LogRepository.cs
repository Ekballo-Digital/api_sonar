using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Infra.Data.Repositories
{
    public class LogRepository : ILogRepository
    {

        private readonly PAINEISContext _context;

        public LogRepository(PAINEISContext context)
        {
            _context = context;
        }

        public async Task<TLogEnvioMsg[]> LogEnvioMsg(DateTime DataMsg, string MatriculaUsuarioMsg, int CodigoEstadoMsg, string DescricaoMsg, int CodigoAreaMsg, int CodigoStatusEnvioMsg)
        {
      
            var sql = "INSERT INTO T_LOG_ENVIO_MSG (DATA_MSG, MATRICULA_USUARIO_MSG, CODIGO_ESTADO_MSG, DESCRICAO_MSG, CODIGO_AREA_MSG, CODIGO_STATUS_ENVIO_MSG) VALUES(@DataMsg, @MatriculaUsuarioMsg, @CodigoEstadoMsg, @DescricaoMsg, @CodigoAreaMsg, @CodigoStatusEnvioMsg);";
            _context.Database.ExecuteSqlRaw(sql,
                new SqlParameter("@DataMsg", DataMsg),
                new SqlParameter("@MatriculaUsuarioMsg", MatriculaUsuarioMsg),
                new SqlParameter("@CodigoEstadoMsg", CodigoEstadoMsg),
                new SqlParameter("@DescricaoMsg", DescricaoMsg),
                new SqlParameter("@CodigoAreaMsg", CodigoAreaMsg),
                new SqlParameter("@CodigoStatusEnvioMsg", CodigoStatusEnvioMsg));

            return null;
        }

        public async Task<TLogOperacao[]> LogOperacao(DateTime DataLogOperacao, string MatriculaUsuarioLogOperacao, int CodigoPerfilLogOperacao, int CodigoFuncaoLogOperacao, string DescricaoLogOperacao, string TipoQueryLogOperacao)
        {
            var sql = "INSERT INTO T_LOG_OPERACAO (DATA_LOG_OPERACAO ,MATRICULA_USUARIO_LOG_OPERACAO ,CODIGO_PERFIL_LOG_OPERACAO ,CODIGO_FUNCAO_LOG_OPERACAO ,DESCRICAO_LOG_OPERACAO ,TIPO_QUERY_LOG_OPERACAO) VALUES(@DataLogOperacao, @MatriculaUsuarioLogOperacao, @CodigoPerfilLogOperacao, @CodigoFuncaoLogOperacao, @DescricaoLogOperacao, @TipoQueryLogOperacao);";
            Console.WriteLine(sql); 

            _context.Database.ExecuteSqlRaw(sql,
                new SqlParameter("@DataLogOperacao", DataLogOperacao),
                new SqlParameter("@MatriculaUsuarioLogOperacao", MatriculaUsuarioLogOperacao),
                new SqlParameter("@CodigoPerfilLogOperacao", CodigoPerfilLogOperacao),
                new SqlParameter("@CodigoFuncaoLogOperacao", CodigoFuncaoLogOperacao),
                new SqlParameter("@DescricaoLogOperacao", DescricaoLogOperacao),
                new SqlParameter("@TipoQueryLogOperacao", TipoQueryLogOperacao));

            return null;
        }
    }
}
