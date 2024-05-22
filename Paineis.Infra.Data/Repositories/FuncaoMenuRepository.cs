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
    public class FuncaoMenuRepository : IFuncaoMenuRepository
    {

        private readonly PAINEISContext _paineisContext;

        public FuncaoMenuRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }
/*
        public async Task<TFuncaoMenu> Alterar(TFuncaoMenu FuncaoMenu)
        {
            _paineisContext.TFuncaoMenus.Update(FuncaoMenu);
            await _paineisContext.SaveChangesAsync();
            return FuncaoMenu;
        }*/

        public async Task<TFuncaoMenu> Excluir(int CodigoMenu, int CodigoFuncao)
        {
            var sql = $"DELETE FROM T_FUNCAO_MENU WHERE CODIGO_MENU = @codigoMenu AND CODIGO_FUNCAO = @codigoFuncao";
            _paineisContext.Database.ExecuteSqlRaw(sql, new SqlParameter("@codigoMenu", CodigoMenu),
                    new SqlParameter("@codigoFuncao", CodigoFuncao));

            return null;
        }

        public async Task<TFuncaoMenu[]> Incluir(TFuncaoMenu FuncaoMenu)
        {
            if (_paineisContext.TFuncaoMenus.Any(a =>
    a.CodigoMenu == FuncaoMenu.CodigoMenu &&
    a.CodigoFuncao == FuncaoMenu.CodigoFuncao))
            {
                TFuncaoMenu[] lista = new TFuncaoMenu[]
                {
        new TFuncaoMenu(401, 0)
                };
                return lista;
            }
            else
            {
                var sql = "INSERT INTO T_FUNCAO_MENU (CODIGO_MENU, CODIGO_FUNCAO) VALUES (@codigoMenu, @codigoFuncao)";
                _paineisContext.Database.ExecuteSqlRaw(sql,
                    new SqlParameter("@codigoMenu", FuncaoMenu.CodigoMenu),
                    new SqlParameter("@codigoFuncao", FuncaoMenu.CodigoFuncao));

                TFuncaoMenu[] lista = new TFuncaoMenu[]
                {
        new TFuncaoMenu(FuncaoMenu.CodigoMenu, FuncaoMenu.CodigoFuncao)
                };
                return lista;
            }
        }

        public async Task<TFuncaoMenu> SelecionarAsync(int CodigoMenu, int CodigoFuncao)
        {
            return await _paineisContext.TFuncaoMenus.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoMenu == CodigoMenu && x.CodigoFuncao == CodigoFuncao);
        }

        public async Task<IEnumerable<TFuncaoMenu>> SelecionarTodosAsync()
        {
            return await _paineisContext.TFuncaoMenus.ToListAsync();
        }
    }
}
