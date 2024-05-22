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
    public class PerfilRepository : IPerfilRepository
    {

        private readonly PAINEISContext _paineisContext;

        public PerfilRepository(PAINEISContext context)
        {
            _paineisContext = context;
        }

        public async Task<TPerfil[]> Alterar(TPerfil alertaAtualizado)
        {
            TPerfil alertaExistente = await _paineisContext.TPerfils.FirstOrDefaultAsync(a => a.CodigoPerfil == alertaAtualizado.CodigoPerfil);

            if (alertaExistente == null)
            {

                TPerfil[] lista = new TPerfil[]
                {
                    new("401")
                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TPerfils.Any(a =>
                a.CodigoPerfil != alertaAtualizado.CodigoPerfil &&
                (a.NomePerfil == alertaAtualizado.NomePerfil)))
            {
                PropertyInfo[] propriedades = typeof(TPerfil).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoPerfil" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TPerfil[] { alertaExistente };
            }
            else
            {
                TPerfil[] lista = new TPerfil[]
                {
                      new("401")
                };

                return lista;
            }
        }

        public async Task<TPerfil[]> Excluir(int CodigoPerfil)
        {
            var var = await _paineisContext.TPerfils.FindAsync(CodigoPerfil);

            if (var != null)
            {
                _paineisContext.TPerfils.Remove(var);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TPerfil[]> Incluir(TPerfil Perfil)
        {
         
            if (_paineisContext.TPerfils.Any(a => a.NomePerfil == Perfil.NomePerfil))
            {
                TPerfil[] lista = new TPerfil[]
                {
                    new("401")

                };

                return lista;
            }
            else
            {
                _paineisContext.TPerfils.Add(Perfil);
                await _paineisContext.SaveChangesAsync();

                TPerfil[] lista = new TPerfil[]
                {
                    new(Perfil.NomePerfil)
                };

                return lista;
            }
        }

        public async Task<TPerfil> SelecionarAsync(int CodigoPerfil)
        {
            return await _paineisContext.TPerfils.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoPerfil == CodigoPerfil);
        }

        public async Task<IEnumerable<TPerfil>> SelecionarTodosAsync()
        {
            return await _paineisContext.TPerfils.ToListAsync();
        }
    }
}
