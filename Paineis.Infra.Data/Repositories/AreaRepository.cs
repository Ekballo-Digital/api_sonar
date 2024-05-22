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
    public class AreaRepository : IAreaRepository
    {

        private readonly PAINEISContext _paineisContext;

        public AreaRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }

        public async Task<TArea[]> Alterar(TArea alertaAtualizado)
        {

            TArea alertaExistente = await _paineisContext.TAreas.FirstOrDefaultAsync(a => a.CodigoArea == alertaAtualizado.CodigoArea);

            if (alertaExistente == null)
            {

                TArea[] lista = new TArea[]
                {
                    new("Area não encontrada.", "401", "")
                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TAreas.Any(a =>
                a.CodigoArea != alertaAtualizado.CodigoArea &&
                (a.NomeArea == alertaAtualizado.NomeArea ||
                 a.SiglaArea == alertaAtualizado.SiglaArea)))
            {
                PropertyInfo[] propriedades = typeof(TArea).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoArea" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TArea[] { alertaExistente };
            }
            else
            {
                TArea[] lista = new TArea[]
                {
                     new("Já existe uma area com a mesmas Descrição.", "401", "")

                };

                return lista;
            }
        }

        public async Task<TArea[]> Excluir(int CodigoArea)
        {
            var var = await _paineisContext.TAreas.FindAsync(CodigoArea);

            if (var != null)
            {
                _paineisContext.TAreas.Remove(var);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TArea[]> Incluir(TArea Area)
        {
            if (_paineisContext.TAreas.Any(a => a.NomeArea == Area.NomeArea))
            {
                TArea[] lista = new TArea[]
                {
                    new("Já existe uma area com a mesmas Descrição.", "401", "")

                };

                return lista;
            }
            else if (_paineisContext.TAreas.Any(a => a.SiglaArea == Area.SiglaArea))
            {
                TArea[] lista = new TArea[]
                {
                   
                    new("Já existe uma sigla com a mesmas Descrição.", "401", "")

                };

                return lista;

            }
            else
            {
                _paineisContext.TAreas.Add(Area);
                await _paineisContext.SaveChangesAsync();
                TArea[] lista = new TArea[]
                {

                    new(Area.NomeArea, Area.SiglaArea, Area.TipoArea)

                };

                return lista;
        
            }
           
        }

        public async Task<TArea> SelecionarAsync(int CodigoArea)
        {
            return await _paineisContext.TAreas.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoArea == CodigoArea);
        }

        public async Task<IEnumerable<TArea>> SelecionarTodosAsync()
        {
            return await _paineisContext.TAreas.ToListAsync();
        }
    }
}
