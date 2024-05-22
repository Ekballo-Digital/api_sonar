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
    public class GenerateMenuService : IGenerateMenu
    {

        private readonly PAINEISContext _context;

        public GenerateMenuService(PAINEISContext context)
        {
            _context = context;
        }

        public async Task<GenerateMenu[]> GenerateMenuAsync(string NomeGrupoAd)
        {
            var sql = $"SELECT DISTINCT c.CODIGO_MENU AS CodigoMenu, d.NOME_MENU AS NomeMenu, URL_MENU as urlMenu FROM T_GRUPO_AD a inner join T_PERFIL b on a.CODIGO_PERFIL = b.CODIGO_PERFIL inner join T_MENU_PERFIL c on a.CODIGO_PERFIL = c.CODIGO_PERFIL inner join T_MENU d on c.CODIGO_MENU = d.CODIGO_MENU where a.NOME_GRUPO_AD = '{NomeGrupoAd}'";
            var var = await _context.GenerateMenus.FromSqlRaw(sql).ToArrayAsync();

            
            return var;
        }
    }
}
