using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Infra.Data.Repositories
{
    public class MenuPerfilRepository : IMenuPerfilRepository
    {

        private readonly PAINEISContext _paineisContext;

        public MenuPerfilRepository(PAINEISContext painContext)
        {
            _paineisContext = painContext;
        }

        /*public async Task<TMenuPerfil[]> Alterar(TMenuPerfil alertaAtualizado)
        {
            // Verifica se o registro existente foi encontrado
            TMenuPerfil alertaExistente = await _paineisContext.TMenuPerfils.FirstOrDefaultAsync(a =>
                a.CodigoPerfil == alertaAtualizado.CodigoPerfil && a.CodigoMenu == alertaAtualizado.CodigoMenu);

            if (alertaExistente == null)
            {
                // Se o registro não existir, retorna um novo alerta padrão
                return new TMenuPerfil[] { new TMenuPerfil(401, 0) };
            }

            // Atualiza as propriedades editáveis do objeto existente com os valores do objeto atualizado
            _paineisContext.Entry(alertaExistente).CurrentValues.SetValues(alertaAtualizado);

            try
            {
                // Salva as alterações no banco de dados
                await _paineisContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Se ocorrer um erro ao salvar as alterações, retorna um novo alerta padrão
                return new TMenuPerfil[] { new TMenuPerfil(401, 0) };
            }

            // Retorna o objeto atualizado como um array para compatibilidade com o código existente
            return new TMenuPerfil[] { alertaExistente };
        }*/

        public async Task<TMenuPerfil> Excluir(int CodigoMenu, int CodigoPerfil)
        {
      
            var sql = $"DELETE FROM T_MENU_PERFIL WHERE CODIGO_PERFIL = @codigoPerfil AND CODIGO_MENU = @codigoMenu";
            _paineisContext.Database.ExecuteSqlRaw(sql, new SqlParameter("@codigoMenu", CodigoMenu),
                    new SqlParameter("@codigoPerfil", CodigoPerfil));

            return null;
        }

        public async Task<TMenuPerfil[]> Incluir(TMenuPerfil MenuPerfil)
        {
            if (_paineisContext.TMenuPerfils.Any(a =>
    a.CodigoPerfil == MenuPerfil.CodigoPerfil &&
    a.CodigoMenu == MenuPerfil.CodigoMenu))
            {
                TMenuPerfil[] lista = new TMenuPerfil[]
                {
        new TMenuPerfil(401, 0)
                };
                return lista;
            }
            else
            {
                var sql = "INSERT INTO T_MENU_PERFIL (CODIGO_MENU, CODIGO_PERFIL) VALUES (@codigoMenu, @codigoPerfil)";
                _paineisContext.Database.ExecuteSqlRaw(sql,
                    new SqlParameter("@codigoMenu", MenuPerfil.CodigoMenu),
                    new SqlParameter("@codigoPerfil", MenuPerfil.CodigoPerfil));

                TMenuPerfil[] lista = new TMenuPerfil[]
                {
        new TMenuPerfil(MenuPerfil.CodigoPerfil, MenuPerfil.CodigoMenu)
                };
                return lista;
            }
        }

        public async Task<TMenuPerfil> SelecionarAsync(int CodigoPerfil, int CodigoMenu)
        {
            return await _paineisContext.TMenuPerfils.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoPerfil == CodigoPerfil && x.CodigoMenu == CodigoMenu);
        }

        public async Task<IEnumerable<TMenuPerfil>> SelecionarTodosAsync()
        {
            return await _paineisContext.TMenuPerfils.ToListAsync();
        }
    }
}
