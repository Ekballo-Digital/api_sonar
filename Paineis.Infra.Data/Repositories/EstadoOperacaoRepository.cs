using Microsoft.EntityFrameworkCore;
using Paineis.Domain.Entities;
using Paineis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Infra.Data.Repositories
{
    public class EstadoOperacaoRepository : IEstadoOperacaoRepository
    {

        private readonly PAINEISContext _paineisContext;

        public EstadoOperacaoRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }

        public async Task<TEstado[]> Alterar(TEstado alertaAtualizado)
        {
            TEstado alertaExistente = await _paineisContext.TEstados.FirstOrDefaultAsync(a => a.CodigoEstado == alertaAtualizado.CodigoEstado);

            if (alertaExistente == null)
            {

                TEstado[] lista = new TEstado[]
                {
                   new("Estado não encontrada.", 401, "")
                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TEstados.Any(a =>
                a.CodigoEstado != alertaAtualizado.CodigoEstado &&
                a.DescricaoEstado == alertaAtualizado.DescricaoEstado))
            {
                PropertyInfo[] propriedades = typeof(TEstado).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoEstado" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TEstado[] { alertaExistente };
            }
            else
            {
                TEstado[] lista = new TEstado[]
                {
                      new("Já existe uma Estado com a mesmas Descrição.", 401, "")

                };

                return lista;
            }
        }

        public async Task<TEstado[]> Excluir(int CodigoEstado)
        {
            var var = await _paineisContext.TEstados.FindAsync(CodigoEstado);

            if (var != null)
            {
                _paineisContext.TEstados.Remove(var);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TEstado[]> Incluir(TEstado Estado)
        {

            if (_paineisContext.TEstados.Any(a => a.DescricaoEstado == Estado.DescricaoEstado))
            {
                TEstado[] lista = new TEstado[]
                {
                    new("Já existe uma Estado com a mesmas Descrição.", 401, "")

                };

                return lista;
            } 
            else
            {
                _paineisContext.TEstados.Add(Estado);
                await _paineisContext.SaveChangesAsync();

                TEstado[] lista = new TEstado[]
               {
                    new(Estado.DescricaoEstado, Estado.CodigoAreaEstado, Estado.TipoEstado)

               };

                return lista;
            }
        }

        public async Task<TEstado> SelecionarAsync(int CodigoEstado)
        {
            return await _paineisContext.TEstados.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoEstado == CodigoEstado);
        }

        public async Task<IEnumerable<TEstado>> SelecionarTodosAsync()
        {
            return await _paineisContext.TEstados.ToListAsync();
        }
    }
}
