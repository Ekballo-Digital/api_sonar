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
    public class PrioridadeRepository : IPrioridadeRepository
    {

        private readonly PAINEISContext _paineisContext;

        public PrioridadeRepository(PAINEISContext paineisContext)
        {
            _paineisContext = paineisContext;
        }

        public async Task<TPrioridade[]> Alterar(TPrioridade alertaAtualizado)
        {

            TPrioridade alertaExistente = await _paineisContext.TPrioridades.FirstOrDefaultAsync(a => a.CodigoPrioridade == alertaAtualizado.CodigoPrioridade);

            if (alertaExistente == null)
            {

                TPrioridade[] lista = new TPrioridade[]
                {
                    new(401, "Prioridade não encontrado.")

                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TPrioridades.Any(a =>
                a.CodigoPrioridade != alertaAtualizado.CodigoPrioridade &&
                (a.NomePrioridade == alertaAtualizado.NomePrioridade) &&

                alertaAtualizado.CodigoPrioridade >= 0))
            {
                PropertyInfo[] propriedades = typeof(TPrioridade).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoPrioridade" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TPrioridade[] { alertaExistente };
            }
            else
            {
                TPrioridade[] lista = new TPrioridade[]
                {
                    new(401, "Já existe uma Prioridade com a mesmas Descrição.")

                };

                return lista;
            }

        }

        public async Task<TPrioridade> Excluir(int CodigoPrioridade)
        {
            var var = await _paineisContext.TPrioridades.FindAsync(CodigoPrioridade);

            if (var != null)
            {
                _paineisContext.TPrioridades.Remove(var);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TPrioridade[]> Incluir(TPrioridade Prio)
        {
            if (_paineisContext.TPrioridades.Any(a => a.CodigoPrioridade == Prio.CodigoPrioridade))
            {
                TPrioridade[] lista = new TPrioridade[]
                {
                    new(401, "Já existe uma Prioridade com a mesmo codigo.")

                };

                return lista;
            }
            else if (_paineisContext.TPrioridades.Any(a => a.NomePrioridade == Prio.NomePrioridade))
            {
                TPrioridade[] lista = new TPrioridade[]
                {
                     new(401, "Já existe uma Prioridade com a mesmas Descrição.")

                };

                return lista;

            }
            else if (Prio.CodigoPrioridade < 0)
            {

                TPrioridade[] lista = new TPrioridade[]
                {
                   
                    new(401, "O codigo prioridade não pode ser menor que zero.")

                };

                return lista;
            }
            else
            {
                _paineisContext.TPrioridades.Add(Prio);
                await _paineisContext.SaveChangesAsync();

                TPrioridade[] lista = new TPrioridade[]
                {
                     new(Prio.CodigoPrioridade, Prio.NomePrioridade)

                };
                return lista;
            }

        }

        public async Task<TPrioridade> SelecionarAsync(int CodigoPrioridade)
        {
            return await _paineisContext.TPrioridades.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoPrioridade == CodigoPrioridade);
        }

        public async Task<IEnumerable<TPrioridade>> SelecionarTodosAsync()
        {
            return await _paineisContext.TPrioridades.ToListAsync();
        }
    }
}
