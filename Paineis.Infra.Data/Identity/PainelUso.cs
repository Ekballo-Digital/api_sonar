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
    public class PainelUso : IPainelUso
    {

        private PAINEISContext _context;

        public PainelUso(PAINEISContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.PainelUsoEntities[]> PegaPainelUso(int CodigoPainel)
        {
            var sql = $"SELECT CODIGO_PAINEL as CodigoPainel, SIGLA_AREA as SiglaArea, TP.CODIGO_AREA as CodigoArea FROM T_PAINEL TP INNER JOIN T_AREA TA ON TP.CODIGO_AREA = TA.CODIGO_AREA WHERE TP.CODIGO_PAINEL = {CodigoPainel};";
            var linha = await _context.PainelUsos.FromSqlRaw(sql).ToArrayAsync();

            return linha;
        }
    }
}
