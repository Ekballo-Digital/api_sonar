using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Infra.Data.Repositories
{
    public class FilaRepository : IFilaRepository
    {

        private readonly PAINEISContext _context;

        public FilaRepository(PAINEISContext context)
        {
            _context = context;
        }

        public async Task<int> FilaEnvio(List<AlertasEntitiesNovo[]> res, string matricula)
        {
            int totalAffectedRows = 0;

            // Iterando sobre cada array na lista
            foreach (var alertasArray in res)
            {
                // Iterando sobre cada AlertasEntities dentro do array
                foreach (var alerta in alertasArray)
                {
                    var sql = "INSERT INTO T_FILA (CODIGO_PAINEL, CODIGO_FILA_MSG, FILA_MSG_ALERTA, FILA_MSG_PRIORIDADE, FILA_MSG_DESC, FILA_AREA_CODIGO_ENVIO, FILA_ENVIO_CODIGO, MATRICULA, PAINEL_ENVIO) VALUES (@CodigoPainel, @CodigoFilaMsg, @FilaMsgAlerta, @FilaMsgPrioridade, @FilaMsgDesc, @FilaAreaCodigoEnvio, 0, @Matricula, @PainelEnvio);";

                    // Execute a inserção no banco de dados usando os dados do alerta
                    int affectedRows = await _context.Database.ExecuteSqlRawAsync(sql,
                        new SqlParameter("@CodigoPainel", await PegaPainel(alerta.CodigoArea)),
                        new SqlParameter("@CodigoFilaMsg", await PegaEstado(alerta.Mensagem)),
                        new SqlParameter("@FilaMsgAlerta", alerta.Alerta),
                        new SqlParameter("@FilaMsgPrioridade", alerta.Prioridade),
                        new SqlParameter("@FilaMsgDesc", alerta.Mensagem),
                        new SqlParameter("@FilaAreaCodigoEnvio", alerta.CodigoArea),
                        //new SqlParameter("@FilaEnvioCodigo", 1),
                        new SqlParameter("@Matricula", matricula),
                        new SqlParameter("@PainelEnvio", alerta.PainelEnvio));

                    totalAffectedRows += affectedRows;
                }
            }

            return totalAffectedRows;
        }

        public async Task<int> FilaEnvioUnico(List<AlertasEntitiesNovo> res, string matricula)
        {
            int totalAffectedRows = 0;

            // Iterando sobre cada AlertasEntities na lista
            foreach (var alerta in res)
            {
                var sql = "INSERT INTO T_FILA (CODIGO_PAINEL, CODIGO_FILA_MSG, FILA_MSG_ALERTA, FILA_MSG_PRIORIDADE, FILA_MSG_DESC, FILA_AREA_CODIGO_ENVIO, FILA_ENVIO_CODIGO, MATRICULA, PAINEL_ENVIO) VALUES (@CodigoPainel, @CodigoFilaMsg, @FilaMsgAlerta, @FilaMsgPrioridade, @FilaMsgDesc, @FilaAreaCodigoEnvio, 0, @Matricula, @PainelEnvio);";

                // Execute a inserção no banco de dados usando os dados do alerta
                int affectedRows = await _context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@CodigoPainel", await PegaPainel(alerta.CodigoArea)),
                    new SqlParameter("@CodigoFilaMsg", GerarNumeroAleatorio(1000000, 100000000)),
                    new SqlParameter("@FilaMsgAlerta", alerta.Alerta),
                    new SqlParameter("@FilaMsgPrioridade", alerta.Prioridade),
                    new SqlParameter("@FilaMsgDesc", alerta.Mensagem),
                    new SqlParameter("@FilaAreaCodigoEnvio", alerta.CodigoArea),
                    new SqlParameter("@Matricula", matricula),
                    new SqlParameter("@PainelEnvio", alerta.PainelEnvio)
                );

                totalAffectedRows += affectedRows;
            }

            return totalAffectedRows;
        }

        public async Task<int> PegaPainel(int codigoArea)
        {
            TPainel var = await _context.TPainels.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoArea == codigoArea); ;
            return var.CodigoPainel;
        }

        public async Task<int> PegaEstado(string estado)
        {
            TEstado var = await _context.TEstados.AsNoTracking().FirstOrDefaultAsync(x => x.DescricaoEstado == estado);

            if (var != null)
            {
                return var.CodigoAreaEstado;
            }
            else
            {
                // Retornar um valor nulo (int?)
                return 999;
            }
        }

        public async Task<TFila[]> DeletaFila(int CodigoFilaMsg)
        {
            var sql = "DELETE FROM T_FILA WHERE CODIGO_FILA_MSG = @CodigoFilaMsg";
            _context.Database.ExecuteSqlRaw(sql,
               new SqlParameter("@CodigoFilaMsg", CodigoFilaMsg));

            return null;
        }

        public async Task<IEnumerable<TFila>> SelectFilaEnvio(string matricula, int PainelEnvio)
        {
            var sql = $"SELECT CODIGO_FILA_MSG AS CODIGO_FILA_MSG, MAX(CODIGO_PAINEL) AS CODIGO_PAINEL, MAX(FILA_MSG_ALERTA) AS FILA_MSG_ALERTA, MAX(FILA_MSG_PRIORIDADE) AS FILA_MSG_PRIORIDADE, CAST(MAX(CAST(FILA_MSG_DESC AS VARCHAR(MAX))) AS TEXT) AS FILA_MSG_DESC, MAX(FILA_AREA_CODIGO_ENVIO) AS FILA_AREA_CODIGO_ENVIO, MAX(FILA_ENVIO_CODIGO) AS FILA_ENVIO_CODIGO, MAX(MATRICULA) AS MATRICULA, MAX(PAINEL_ENVIO) AS PAINEL_ENVIO FROM T_FILA WHERE MATRICULA = '{matricula}' AND PAINEL_ENVIO = {PainelEnvio} GROUP BY CODIGO_FILA_MSG;";
            var res = await _context.TFilas.FromSqlRaw(sql).ToArrayAsync();

            return res;
        }

        public int GerarNumeroAleatorio(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }

        public async Task<IEnumerable<TFila>> SelectFilaEnvioGeral(int CodigoPainel)
        {
            return await _context.TFilas.AsNoTracking().Where(x => x.CodigoPainel == CodigoPainel).ToListAsync();
        }

        public async Task<int> UpdateRespostaPainel(int CodigoArea, string Mensagem, int CodigoAlerta)
        {
            var codigoPainel = await PegaPainel(CodigoArea);
            var codigoFilaMsg = await PegaEstado(Mensagem);

            if (codigoFilaMsg == 999)
            {

                return 0; // ou lançar uma exceção, dependendo do comportamento desejado
            }

            TFila var = await _context.TFilas.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoPainel == codigoPainel && x.CodigoFilaMsg == codigoFilaMsg && x.FilaMsgAlerta == CodigoAlerta);

            if (var == null)
            {
                
                return 0; // ou lançar uma exceção, dependendo do comportamento desejado
            }

            // Verifica se FilaEnvioCodigo é nulo
            if (var.FilaEnvioCodigo == null)
            {
                return 0; // Ou qualquer outro valor ou ação apropriada
            }

            var codigoEnvio = var.FilaEnvioCodigo;

            int totalAffectedRows = 0;

            var sql = "UPDATE T_FILA SET FILA_ENVIO_CODIGO = @FilaEnvioCodigo WHERE CODIGO_PAINEL = @CodigoPainel AND CODIGO_FILA_MSG = @CodigoFilaMsg";

            // Execute a inserção no banco de dados usando os dados do alerta
            int affectedRows = await _context.Database.ExecuteSqlRawAsync(sql,
                new SqlParameter("@FilaEnvioCodigo", codigoEnvio + 1),
                new SqlParameter("@CodigoPainel", codigoPainel),
                new SqlParameter("@CodigoFilaMsg", codigoFilaMsg));

            totalAffectedRows += affectedRows;

            return totalAffectedRows;
        }

        public async Task<GruposMsg[]> FilaGrupos()
        {

            var sql = "SELECT CODIGO_FILA_MSG as CodigoFilaMsg FROM T_FILA GROUP BY CODIGO_FILA_MSG;";
            var linha = await _context.GruposMsgs.FromSqlRaw(sql).ToArrayAsync();

            return linha;
        }
    }
}
