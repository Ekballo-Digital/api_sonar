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
    public class AuthDoubleAdService : IAuthDoubleAd
    {

        private readonly PAINEISContext _painContext;

        public AuthDoubleAdService(PAINEISContext painContext)
        {
            _painContext = painContext;
        }

        public async Task<AuthDoubleAd[]> AuthenticateDoubleAdAsync(string NomeGrupoAd)
        {
            var sql = $"SELECT a.CODIGO_PERFIL as CodigoPerfil, a.CODIGO_AREA_GRUPO_AD as CodigoAreaGrupoAd, b.NOME_PERFIL as NomePerfil FROM T_GRUPO_AD a inner join T_PERFIL b on a.CODIGO_PERFIL = b.CODIGO_PERFIL inner join T_MENU_PERFIL c on a.CODIGO_PERFIL = c.CODIGO_PERFIL inner join T_MENU d on c.CODIGO_MENU = d.CODIGO_MENU where a.NOME_GRUPO_AD = '{NomeGrupoAd}';";

            var var = await _painContext.AuthDoubleAds.FromSqlRaw(sql).ToArrayAsync();

            AuthDoubleAd[] listaAuth = new AuthDoubleAd[]
            {
                new AuthDoubleAd
                {       
                   CodigoPerfil = var[0].CodigoPerfil,
                   CodigoAreaGrupoAd = var[0].CodigoAreaGrupoAd,
                   NomePerfil = var[0].NomePerfil
                },

            };

            return listaAuth;
        }
    }
}
