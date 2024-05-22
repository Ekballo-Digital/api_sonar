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
    public class MenuRepository : IMenuRepository
    {
        private readonly PAINEISContext _paineisContext;

        public MenuRepository(PAINEISContext pAINEISContext)
        {
            _paineisContext = pAINEISContext;
        }

        public async Task<TMenu[]> Alterar(TMenu alertaAtualizado)
        {
            TMenu alertaExistente = await _paineisContext.TMenus.FirstOrDefaultAsync(a => a.CodigoMenu == alertaAtualizado.CodigoMenu);

            if (alertaExistente == null)
            {

                TMenu[] lista = new TMenu[]
                {
                    new("Já existe um Menu com a mesmas Descrição.", "401")
                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TMenus.Any(a =>
                a.CodigoMenu != alertaAtualizado.CodigoMenu &&
                (a.NomeMenu == alertaAtualizado.NomeMenu) ||
                (a.UrlMenu == alertaAtualizado.UrlMenu)))
            {
                PropertyInfo[] propriedades = typeof(TMenu).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoMenu" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TMenu[] { alertaExistente };
            }
            else
            {
                TMenu[] lista = new TMenu[]
                {
                      new("Já existe um Menu com a mesmas Descrição22", "401")
                };

                return lista;
            }


           
        }

        public async Task<TMenu> Excluir(int CodigoMenu)
        {
            var var = await _paineisContext.TMenus.FindAsync(CodigoMenu);

            if (var != null)
            {
                _paineisContext.TMenus.Remove(var);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TMenu[]> Incluir(TMenu Menu)
        {
            if (_paineisContext.TMenus.Any(a => a.NomeMenu == Menu.NomeMenu))
            {
                TMenu[] lista = new TMenu[]
                {
                    new("Já existe um Menu com a mesmas Descrição.", "401")

                };

                return lista;
            }
            else if (_paineisContext.TMenus.Any(a => a.UrlMenu == Menu.UrlMenu))
            {
                TMenu[] lista = new TMenu[]
                {
                     new("Já existe uma url com a mesmas Descrição.", "401")

                };

                return lista;

            }
            else
            {
                _paineisContext.TMenus.Add(Menu);
                await _paineisContext.SaveChangesAsync();
                TMenu[] lista = new TMenu[]
                {
                     new(Menu.NomeMenu, Menu.UrlMenu)

                };

                return lista;
            }
        }

        public async Task<TMenu> SelecionarAsync(int CodigoMenu)
        {
            return await _paineisContext.TMenus.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoMenu == CodigoMenu);
        }

        public async Task<IEnumerable<TMenu>> SelecionarTodosAsync()
        {
            return await _paineisContext.TMenus.ToListAsync();
        }
    }
}
