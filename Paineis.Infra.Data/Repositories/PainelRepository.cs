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
    public class PainelRepository : IPainelRepository
    {

        private readonly PAINEISContext _paineisContext;

        public PainelRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }

        public async Task<TPainel[]> Alterar(TPainel alertaAtualizado)
        {
            TPainel alertaExistente = await _paineisContext.TPainels.FirstOrDefaultAsync(a => a.CodigoPainel == alertaAtualizado.CodigoPainel);

            if (alertaExistente == null)
            {

                TPainel[] lista = new TPainel[]
                {
                    new("Já existe uma Painel com a mesmo Ip.", 401, 0, 0)
                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TPainels.Any(a =>
                a.CodigoPainel != alertaAtualizado.CodigoPainel &&
                (a.IpPainel == alertaAtualizado.IpPainel)))
            {
                PropertyInfo[] propriedades = typeof(TPainel).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoPainel" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TPainel[] { alertaExistente };
            }
            else
            {
                TPainel[] lista = new TPainel[]
                {
                     new("Já existe um painel com o mesmas Ip.", 401, 0, 0)
                };

                return lista;
            }
        }

        public async Task<TPainel[]> Excluir(int CodigoPainel)
        {
            var var = await _paineisContext.TPainels.FindAsync(CodigoPainel);

            if (var != null)
            {
                _paineisContext.TPainels.Remove(var);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TPainel[]> Incluir(TPainel Painel)
        {
            if (_paineisContext.TPainels.Any(a => a.IpPainel == Painel.IpPainel))
            {
                TPainel[] lista = new TPainel[]
                {
                    new("Já existe uma Painel com a mesmo Ip.", 401, 0, 0)
                };

                return lista;
            }
            else
            {
                _paineisContext.TPainels.Add(Painel);
                await _paineisContext.SaveChangesAsync();
                TPainel[] lista = new TPainel[]
                 {
                    new(Painel.IpPainel, Painel.CodigoArea, Painel.PortaPainel, Painel.StatusPainel)
                 };

                return lista;
            }
        }

        public async Task<TPainel> SelecionarAsync(int CodigoPainel)
        {
            return await _paineisContext.TPainels.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoPainel == CodigoPainel);
        }

        public async Task<TPainel> SelecionarIpPort(int CodigoArea)
        {
            return await _paineisContext.TPainels.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoArea == CodigoArea);
        }

        public async Task<TCorSocket[]> SelecionarCorPainel(int CodigoAlerta)
        {
            var sql = $"SELECT DESCRICAO_COR as DescricaoCor FROM T_ALERTA TA INNER JOIN T_COR TC ON TA.CODIGO_COR = TC.CODIGO_COR WHERE NIVEL_ALERTA = {CodigoAlerta}";
            var var = await _paineisContext.TCorSockets.FromSqlRaw(sql).ToArrayAsync();
            return var;
        } 
        
        public async Task<IEnumerable<TFila>> SelecionarFilaPainel()
        {
            return await _paineisContext.TFilas
                                 .OrderByDescending(f => f.FilaMsgPrioridade)
                                 .ToListAsync();

        }

        public async Task<IEnumerable<TFila>> SelecionarFilaPainelGrupo(int grupo)
        {
            return await _paineisContext.TFilas
                                .Where(f => f.CodigoFilaMsg == grupo)
                                 .OrderByDescending(f => f.FilaMsgPrioridade)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<TPainel>> SelecionarTodosAsync()
        {
            return await _paineisContext.TPainels.ToListAsync();
        }
    }
}
