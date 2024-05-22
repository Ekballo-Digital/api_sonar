using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Paineis.Application.Interfaces;
using Paineis.Application.Mappings;
using Paineis.Application.Services;
using Paineis.Domain.Account;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using Paineis.Infra.Data.Identity;
using Paineis.Infra.Data.Repositories;
using System.Text;

namespace Paineis.Infra.Ioc
{
    public static class DependecyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PAINEISContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            //Repositorio
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITgrupoAdRepository, TGrupoAdRepository>();
            services.AddScoped<ITabelaMatriz, GerarSilgasTabelaMatrizRepository>();
            services.AddScoped<IEnviarMensagem, EnviarMensagemRepository>();
            services.AddScoped<ISelect, SelectsRepository>();
            services.AddScoped<IAlertaRepository, AlertaRepository>();
            services.AddScoped<ICorRepository, CorRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IPainelRepository, PainelRepository>();
            services.AddScoped<IPrioridadeRepository, PrioridadeRepository>();
            services.AddScoped<IEstadoOperacaoRepository, EstadoOperacaoRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuPerfilRepository, MenuPerfilRepository>();
            services.AddScoped<IFuncaoMenuRepository, FuncaoMenuRepository>();
            services.AddScoped<IFuncaoSistemaRepository, FuncaoSistemaRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IMatrizRepository, MatrizRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IFilaRepository, FilaRepository>();

            //Serviços
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ITgrupoAdService, TGrupoAdService>();
            services.AddScoped<IGenerateMenu, GenerateMenuService>();
            services.AddScoped<IGeneratePainel, GeneratePainelService>();
            services.AddScoped<IAuthDoubleAd, AuthDoubleAdService>();
            services.AddScoped<IFuncaoMenuGenerate, FuncaoMenuGenerateService>();
            services.AddScoped<IPainelUso, PainelUso>();
            services.AddScoped<IAlertaService, AlertaService>();
            services.AddScoped<ICorService, CorService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IPainelService, PainelService>();
            services.AddScoped<IPrioridadeService, PrioridadeService>();
            services.AddScoped<IEstadoOperacaoService, EstadoOperacaoService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuPerfilService, MenuPerfilService>();
            services.AddScoped<IFuncaoMenuService, FuncaoMenuService>();
            services.AddScoped<IFuncaoSistemaService, FuncaoSistemaService>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<IMatrizService, MatrizService>();
            services.AddScoped<ISocketServerPainelService, SocketServerPainelService>();
            services.AddScoped<IFilaService, FilaService>();
            services.AddScoped<IMiddleWareWeb, IMiddleWareWebService>();
            

            services.AddHostedService<SocketServerPainelHostedService>();
            services.AddSingleton<SocketServerPainelHostedService>();

            return services;
        }

    }
}