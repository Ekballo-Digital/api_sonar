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
    public class FuncaoMenuGenerateService : IFuncaoMenuGenerate
    {
        private readonly PAINEISContext _context;

        public FuncaoMenuGenerateService(PAINEISContext context)
        {
            _context = context;
        }

        public async Task<FuncaoMenuGenerate[]> FuncaoMenuGenerateAsync(int CodigoMenu)
        {
            var sql = $"SELECT TFM.CODIGO_FUNCAO as CodigoFuncao, DESCRICAO_FUNCAO as DescricaoFuncao, TF.URL_FUNCAO as urlFuncao, TF.ICON_SVG as iconSvg FROM T_FUNCAO_MENU TFM INNER JOIN T_MENU TM ON TFM.CODIGO_MENU = TM.CODIGO_MENU INNER JOIN T_FUNCAO TF ON TFM.CODIGO_FUNCAO = TF.CODIGO_FUNCAO WHERE TFM.CODIGO_MENU = {CodigoMenu} AND TFM.CODIGO_FUNCAO NOT IN (28,29) ORDER BY NOME_MENU, DESCRICAO_FUNCAO ASC";
            var var = await _context.FuncaoMenuGenerates.FromSqlRaw(sql).ToArrayAsync();

            return var;

        }
    }
}
