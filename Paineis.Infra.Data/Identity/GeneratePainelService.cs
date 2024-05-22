using Microsoft.EntityFrameworkCore;
using Paineis.Domain.Account;
using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Infra.Data.Identity
{
    public class GeneratePainelService : IGeneratePainel
    {

        private readonly PAINEISContext _painelContext;

        public GeneratePainelService(PAINEISContext painelContext)
        {
            _painelContext = painelContext;
        }

        public async Task<GeneratePainel[]> GeneratePainelAsync(string NomeGrupoAd)
        {
            var sql = $"SELECT CODIGO_PAINEL as CodigoPainel, SIGLA_AREA as SiglaArea FROM T_PAINEL TP INNER JOIN T_AREA TA ON TP.CODIGO_AREA = TA.CODIGO_AREA INNER JOIN T_GRUPO_AD TAD ON TA.CODIGO_AREA = TAD.CODIGO_AREA_GRUPO_AD WHERE TAD.NOME_GRUPO_AD = '{NomeGrupoAd}' AND TP.STATUS_PAINEL = 1;";
            var var = await _painelContext.GeneratePaineis.FromSqlRaw(sql).ToArrayAsync();

            return var;


        }
    }
}
