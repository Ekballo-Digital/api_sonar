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
    public class MatrizRepository : IMatrizRepository
    {

        private readonly PAINEISContext _paineisContext;

        public MatrizRepository(PAINEISContext context)
        {
            _paineisContext = context;
        }

        public async Task<TMatrizUpdate[]> Alterar(TMatrizUpdate Matriz)
        {
            var sql = $"UPDATE T_MATRIZ SET CODIGO_ESTADO = @codigoEstado, CODIGO_AREA = @codigoArea, CODIGO_ALERTA = @codigoAlerta, CODIGO_PRIORIDADE = @codigoPrioridade WHERE CODIGO_ESTADO = {Matriz.CodigoEstado} AND CODIGO_AREA = {Matriz.CodigoArea} AND CODIGO_ALERTA = {Matriz.CodigoAlerta} AND CODIGO_PRIORIDADE = {Matriz.CodigoPrioridade}";
            _paineisContext.Database.ExecuteSqlRaw(sql, new SqlParameter("@codigoEstado", Matriz.CodigoEstadoNovo),
                    new SqlParameter("@codigoArea", Matriz.CodigoAreaNovo),
                    new SqlParameter("@codigoAlerta", Matriz.CodigoAlertaNovo),
                    new SqlParameter("@codigoPrioridade", Matriz.CodigoPrioridadeNovo)
                    );

            return null;
        }

        public async Task<TMatriz> Excluir(int CodigoEstado, int CodigoArea, int CodigoAlerta, int CodigoPrioridade)
        {
            var sql = $"DELETE FROM T_MATRIZ WHERE CODIGO_ESTADO = @codigoEstado AND CODIGO_AREA = @codigoArea AND CODIGO_ALERTA = @codigoAlerta AND CODIGO_PRIORIDADE = @codigoPrioridade;";
            _paineisContext.Database.ExecuteSqlRaw(sql, new SqlParameter("@codigoEstado", CodigoEstado),
                    new SqlParameter("@codigoArea", CodigoArea),
                    new SqlParameter("@codigoAlerta", CodigoAlerta),
                    new SqlParameter("@codigoPrioridade", CodigoPrioridade)
                    );

            return null;
        }

        public async Task<TMatriz[]> Incluir(TMatriz alertaAtualizado)
        {

            if (_paineisContext.TMatrizs.Any(a =>
                a.CodigoEstado == alertaAtualizado.CodigoEstado &&
                a.CodigoArea == alertaAtualizado.CodigoArea &&
                a.CodigoAlerta == alertaAtualizado.CodigoAlerta &&
                a.CodigoPrioridade == alertaAtualizado.CodigoPrioridade
))
            {
                TMatriz[] lista = new TMatriz[]
                {
                    new TMatriz(401, 0, 0, 0)
                };
                return lista;
            }
            else
            {
                var sql = "INSERT INTO T_MATRIZ (CODIGO_ESTADO, CODIGO_AREA, CODIGO_ALERTA, CODIGO_PRIORIDADE) VALUES (@codigoEstado, @codigoArea, @codigoAlerta, @codigoPrioridade);";
                _paineisContext.Database.ExecuteSqlRaw(sql,
                    new SqlParameter("@codigoEstado", alertaAtualizado.CodigoEstado),
                    new SqlParameter("@codigoArea", alertaAtualizado.CodigoArea),
                    new SqlParameter("@codigoAlerta", alertaAtualizado.CodigoAlerta),
                    new SqlParameter("@codigoPrioridade", alertaAtualizado.CodigoPrioridade));

                TMatriz[] lista = new TMatriz[]
                {
                    new TMatriz(alertaAtualizado.CodigoEstado, alertaAtualizado.CodigoArea, alertaAtualizado.CodigoAlerta, alertaAtualizado.CodigoPrioridade)
                };
                return lista;
            }

        }

        public async Task<TMatriz> SelecionarAsync(int CodigoEstado, int CodigoArea)
        {
            return await _paineisContext.TMatrizs.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoEstado == CodigoEstado && x.CodigoArea == CodigoArea);
        }

        public async Task<IEnumerable<TMatriz>> SelecionarTodosAsync()
        {
            return await _paineisContext.TMatrizs.ToListAsync();
        }
    }
}
