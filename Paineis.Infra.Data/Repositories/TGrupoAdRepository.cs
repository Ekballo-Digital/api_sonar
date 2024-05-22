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
    public class TGrupoAdRepository : ITgrupoAdRepository
    {
        private readonly PAINEISContext _paineisContext;

        public TGrupoAdRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }

        public async Task<TGrupoAd[]> Alterar(TGrupoAd alertaAtualizado)
        {
            TGrupoAd alertaExistente = await _paineisContext.TGrupoAds.FirstOrDefaultAsync(a => a.CodigoGrupoAd == alertaAtualizado.CodigoGrupoAd);

            if (alertaExistente == null)
            {

                TGrupoAd[] lista = new TGrupoAd[]
                {
                    new("Grupo não encontrado.", 401, 0)

                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TGrupoAds.Any(a =>
                a.CodigoGrupoAd != alertaAtualizado.CodigoGrupoAd &&
                (a.NomeGrupoAd == alertaAtualizado.NomeGrupoAd &&
                 a.CodigoPerfil == alertaAtualizado.CodigoPerfil &&
                 a.CodigoAreaGrupoAd == alertaAtualizado.CodigoAreaGrupoAd)))
            {
                PropertyInfo[] propriedades = typeof(TGrupoAd).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoGrupoAd" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TGrupoAd[] { alertaExistente };
            }
            else
            {
                TGrupoAd[] lista = new TGrupoAd[]
                {
                    new("Já existe um grupo com essas informações.", 401, 0)

                };

                return lista;
            } 

        }

        public async Task<TGrupoAd[]> Excluir(int CodigoGrupoAd)
        {
            var NomeGrupoAd = await _paineisContext.TGrupoAds.FindAsync(CodigoGrupoAd);

            if (NomeGrupoAd != null)
            {
                _paineisContext.TGrupoAds.Remove(NomeGrupoAd);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TGrupoAd[]> Incluir(TGrupoAd NomeGrupoAd)
        {
            if (_paineisContext.TGrupoAds.Any(a => 
            a.NomeGrupoAd == NomeGrupoAd.NomeGrupoAd &&
            a.CodigoPerfil == NomeGrupoAd.CodigoPerfil &&
            a.CodigoAreaGrupoAd == NomeGrupoAd.CodigoAreaGrupoAd))
            {

                TGrupoAd[] lista = new TGrupoAd[]
                {
                    new("Já existe um grupo com essas informações.", 401, 0)

                };

                return lista;
            }
            else
            {
                _paineisContext.TGrupoAds.Add(NomeGrupoAd);
                await _paineisContext.SaveChangesAsync();

                TGrupoAd[] lista = new TGrupoAd[]
                {
                    new(NomeGrupoAd.NomeGrupoAd, NomeGrupoAd.CodigoPerfil, NomeGrupoAd.CodigoAreaGrupoAd)

                };

                return lista;
            }
        }

        public async Task<TGrupoAd> SelecionarAsync(int CodigoGrupoAd)
        {
            return await _paineisContext.TGrupoAds.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoGrupoAd == CodigoGrupoAd);
        }

        public async Task<IEnumerable<TGrupoAd>> SelecionarTodosAsync()
        {
            return await _paineisContext.TGrupoAds.ToListAsync();
        }
    }
}
