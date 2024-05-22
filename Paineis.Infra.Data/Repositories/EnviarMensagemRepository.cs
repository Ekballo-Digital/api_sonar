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
    public class EnviarMensagemRepository : IEnviarMensagem
    {
        private readonly PAINEISContext _paineisContext;

        public EnviarMensagemRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }

        public async Task<NivelAlerta[]> PegaAlerta()
        {
            var sql = "SELECT NIVEL_ALERTA AS AlertaNivel FROM T_ALERTA";
            var result = await _paineisContext.NivelAlertas.FromSqlRaw(sql).ToArrayAsync();
            return result;
        }

        public async Task<NivelAlerta2[]> PegaAlerta2()
        {
            var sql = "SELECT CODIGO_ALERTA AS CodigoAlerta, NIVEL_ALERTA AS AlertaNivel FROM T_ALERTA";
            var result = await _paineisContext.NivelAlertas2.FromSqlRaw(sql).ToArrayAsync();
            return result;
        }

        public async Task<PegaEstado[]> PegaEstado(int CodigoEstado)
        {
            var sql = $"SELECT DESCRICAO_ESTADO as DescricaoEstado, NIVEL_ALERTA as NivelAlerta, CODIGO_PRIORIDADE as CodigoPrioridade, DESCRICAO_COR as DescCor, SIGLA_AREA as SiglaArea, TAR.CODIGO_AREA as CodigoArea, TIPO_ESTADO as TipoEstado, HEXA_COR_RED as Red, HEXA_COR_GREEN as Green, HEXA_COR_BLUE as Blue FROM T_MATRIZ TM INNER JOIN T_ESTADO TS ON TM.CODIGO_ESTADO = TS.CODIGO_ESTADO \r\nINNER JOIN T_ALERTA TA ON TM.CODIGO_ALERTA = TA.CODIGO_ALERTA INNER JOIN T_COR TC ON TA.CODIGO_COR = TC.CODIGO_COR INNER JOIN T_AREA TAR ON TM.CODIGO_AREA = TAR.CODIGO_AREA WHERE TS.CODIGO_ESTADO = {CodigoEstado} AND SIGLA_AREA NOT IN ('TI', 'GERAL')";
            var result = await _paineisContext.PegaEstados.FromSqlRaw(sql).ToArrayAsync();
            return result;
        }

        public async Task<PegaPrioridade[]> PegaPrioridade()
        {
            var sql = "SELECT CODIGO_PRIORIDADE AS CodigoPrioridade, NOME_PRIORIDADE AS NomePrioridade FROM T_PRIORIDADE";
            var result = await _paineisContext.PegaPrioridades.FromSqlRaw(sql).ToArrayAsync();
            return result;
        }
    }
}
