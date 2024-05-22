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
    public class GerarSilgasTabelaMatrizRepository : ITabelaMatriz
    {
        private readonly PAINEISContext _paineisContext;

        public GerarSilgasTabelaMatrizRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }

        public async Task<GerarAlertasTabelaMatrizEntities[]> GerarAlertasTabela(int CodigoEstado)
        {
            var sql = $"SELECT NIVEL_ALERTA AS NivelAlerta, HEXA_COR_RED AS Red, HEXA_COR_GREEN AS Green, HEXA_COR_BLUE AS Blue, CODIGO_PRIORIDADE AS CodigoPrioridade, TIPO_ESTADO AS TipoEstado FROM T_MATRIZ TM (NOLOCK) INNER JOIN T_ESTADO TE (NOLOCK) ON TM.CODIGO_ESTADO = TE.CODIGO_ESTADO INNER JOIN T_AREA TA (NOLOCK) ON TM.CODIGO_AREA = TA.CODIGO_AREA INNER JOIN T_ALERTA TAL (NOLOCK) ON TM.CODIGO_ALERTA = TAL.CODIGO_ALERTA INNER JOIN T_COR TC (NOLOCK) ON TAL.CODIGO_COR = TC.CODIGO_COR WHERE SIGLA_AREA NOT IN ('TI') AND TM.CODIGO_ESTADO = {CodigoEstado} AND TIPO_ESTADO NOT IN ('L') ORDER BY SIGLA_AREA ASC;";
            var result = await _paineisContext.GerarAlertasTabelaMatrizes.FromSqlRaw(sql).ToArrayAsync();
            return result;
        }

        public async Task<GerarEstadosTabelaMatrizEntities[]> GerarEstadoTabela(int CodigoArea)
        {
            var sql = $"SELECT CODIGO_ESTADO as CodigoEstado, DESCRICAO_ESTADO as DescricaoEstado, TIPO_ESTADO as TipoEstado FROM T_ESTADO WHERE CODIGO_AREA_ESTADO = {CodigoArea} ORDER BY TIPO_ESTADO ASC";

            var result = await _paineisContext.GerarEstadosTabelaMatrizes.FromSqlRaw(sql).ToArrayAsync();

            return result;
        }

        public async Task<GerarSilgasTabelaMatrizEntities[]> GerarSilgasTabela()
        {

            var sqlGeral = $"SELECT CODIGO_AREA as CodigoArea, SIGLA_AREA as SiglaArea FROM T_AREA WHERE SIGLA_AREA NOT IN ('TI', 'GERAL') ORDER BY SIGLA_AREA ASC";

            var result = await _paineisContext.GerarSilgasTabelaMatrizes.FromSqlRaw(sqlGeral).ToArrayAsync();

            return result;
        }


    }
}
