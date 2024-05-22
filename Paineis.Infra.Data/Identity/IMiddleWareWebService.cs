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
    public class IMiddleWareWebService : IMiddleWareWeb
    {
        private readonly PAINEISContext _context;

        public IMiddleWareWebService(PAINEISContext context)
        {
            _context = context;
        }

        public async Task<ValPainel[]> ValidaPainelUsuario(int CodigoPainel, string NomeGrupoAd)
        {
            var sql = $"SELECT TG.NOME_GRUPO_AD as NomeGrupoAd FROM T_PAINEL TP \r\nINNER JOIN T_AREA TA ON TP.CODIGO_AREA = TA.CODIGO_AREA\r\nINNER JOIN T_GRUPO_AD TG ON TG.CODIGO_AREA_GRUPO_AD = TA.CODIGO_AREA \r\nWHERE TP.CODIGO_PAINEL = {CodigoPainel} AND NOME_GRUPO_AD = '{NomeGrupoAd}';";

            var val = await _context.ValPainels.FromSqlRaw(sql).ToArrayAsync();

            return val;
        }

        public async Task<ValidaUrlsWeb[]> ValidaUrls(string NomeGrupoAd, string url)
        {
            var sql = $"SELECT DISTINCT URL_MENU as urlMenu FROM T_GRUPO_AD a \r\nINNER JOIN T_MENU_PERFIL c on a.CODIGO_PERFIL = c.CODIGO_PERFIL \r\nINNER JOIN T_MENU d on c.CODIGO_MENU = d.CODIGO_MENU\r\nwhere a.NOME_GRUPO_AD = '{NomeGrupoAd}' and URL_MENU = '{url}';";

            var val = await _context.ValidaUrlsWebs.FromSqlRaw(sql).ToArrayAsync();

            return val;
        }
    }
}
