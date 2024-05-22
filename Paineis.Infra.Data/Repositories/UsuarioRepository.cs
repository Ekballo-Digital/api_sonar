using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using Paineis.Infra.Data;

namespace Paineis.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly PAINEISContext _paineisContext;

        public UsuarioRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }

        public async Task<TGrupoAd> Alterar(TGrupoAd NomeGrupoAd)
        {
            _paineisContext.TGrupoAds.Update(NomeGrupoAd);
            await _paineisContext.SaveChangesAsync();
            return NomeGrupoAd;

        }

        public async Task<TGrupoAd> Excluir(int CodigoGrupoAd)
        {
            var NomeGrupoAd = await _paineisContext.TGrupoAds.FindAsync(CodigoGrupoAd);

            if (NomeGrupoAd != null)
            {
                _paineisContext.TGrupoAds.Remove(NomeGrupoAd);
                await _paineisContext.SaveChangesAsync(); 
            }

            return null;
        }

        public async Task<TGrupoAd> Incluir(TGrupoAd NomeGrupoAd)
        {
            _paineisContext.TGrupoAds.Add(NomeGrupoAd);
            await _paineisContext.SaveChangesAsync(); 
            return NomeGrupoAd;
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
