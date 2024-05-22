using Paineis.Domain.Account;
using Paineis.Domain.Entities;
using System.DirectoryServices.AccountManagement;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace Paineis.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly PAINEISContext _context;
        private readonly IConfiguration _configuration;
       

        public AuthenticateService(PAINEISContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public async Task<Auth[]> AuthenticateAsync(string matricula, string senha)
        {

            try { 

            PrincipalContext context = new(ContextType.Domain, "MASTER");
            
            bool resultado = context.ValidateCredentials(matricula, senha);

            Console.WriteLine(resultado);

            if (resultado == true)
            {
                
                UserPrincipal usuario = UserPrincipal.FindByIdentity(context, matricula);

                PrincipalSearchResult<Principal> GruposAd = usuario.GetGroups(context);

                var GruposAdUsuario = GruposAd.Select(x => x.Name).ToList();

                var GruposAdBanco = _context.TGrupoAds.Select(x => x.NomeGrupoAd).ToList();

                var ListaItensComparacao = GruposAdUsuario.Intersect(GruposAdBanco).ToList();

                int QtdItensLista = ListaItensComparacao.Count();

                //Console.WriteLine(ListaItensComparacao);
                //QtdItensLista = 2;

                string GrupoIgual = ListaItensComparacao.FirstOrDefault();

                var sql = $"SELECT a.NOME_GRUPO_AD as NomeGrupoAd, a.CODIGO_PERFIL as CodigoPerfil, a.CODIGO_AREA_GRUPO_AD as CodigoGrupoAreaAd, b.NOME_PERFIL as NomePerfil FROM T_GRUPO_AD a inner join T_PERFIL b on a.CODIGO_PERFIL = b.CODIGO_PERFIL inner join T_MENU_PERFIL c on a.CODIGO_PERFIL = c.CODIGO_PERFIL inner join T_MENU d on c.CODIGO_MENU = d.CODIGO_MENU where a.NOME_GRUPO_AD = '{GrupoIgual}';";

                var var = await _context.InfoLogins.FromSqlRaw(sql).ToArrayAsync();

                if (QtdItensLista == 1)
                {
                    

                    Auth[] listaAuth = new Auth[]
{
                        new Auth
                        {
                            NomeGrupoAd = { var[0].NomeGrupoAd },
                            CodigoPerfil = var[0].CodigoPerfil,
                            CodigoAreaGrupoAd = var[0].CodigoGrupoAreaAd,
                            NomePerfil = var[0].NomePerfil,
                            MatriculaUsuario = matricula.ToUpper(),
                            NomeUsuario = usuario.DisplayName,
                            Token = GenerateToken(matricula.ToUpper(), usuario.DisplayName, var[0].CodigoPerfil),
                            StatusCode = 200
                        },
 
                    };

                    return listaAuth;
                }
                else if (string.IsNullOrEmpty(GrupoIgual))
                {
                   
                    Auth[] listaAuth = new Auth[]
                    {
                        new Auth
                        {
                            MatriculaUsuario = matricula.ToUpper(),
                            StatusCode = 203
                        },

                    };

                    return listaAuth;

                }
                else if (QtdItensLista > 1)
                {

                    //ListaItensComparacao.Add("s-corp-pcte2mso-rp");

                    Auth[] listaAuth = new Auth[]
{
                        new Auth
                        {
                            NomeGrupoAd =  { ListaItensComparacao },
                            MatriculaUsuario = matricula.ToUpper(),
                            NomeUsuario = usuario.DisplayName,
                            Token = GenerateToken(matricula.ToUpper(), usuario.DisplayName, var[0].CodigoPerfil),
                            StatusCode = 300
                        },

                    };

                    return listaAuth;
                }

            }
            else
            {
              

                 Auth[] listaAuth = new Auth[]
{
                        new Auth
                        {
                           
                            StatusCode = 401
                        },

                    };

                return listaAuth;
            }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            return null;

        }

        public string GenerateToken(string matricula, string NomeUsuario, int CodigoPerfil)
        {
            var claims = new[]
            {
                new Claim("matricula", matricula.ToString()),
                new Claim("NomeUsuario", NomeUsuario.ToString().ToLower()),
                new Claim("CodigoPerfil", CodigoPerfil.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(60);

            JwtSecurityToken token = new(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
