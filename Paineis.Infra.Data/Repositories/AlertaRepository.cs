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
    public class AlertaRepository : IAlertaRepository
    {
        private readonly PAINEISContext _paineisContext;

        public AlertaRepository(PAINEISContext context)
        {
            _paineisContext = context;
        }

        public async Task<TAlertum[]> Alterar(TAlertum alertaAtualizado)
        {
            TAlertum alertaExistente = await _paineisContext.TAlerta.FirstOrDefaultAsync(a => a.CodigoAlerta == alertaAtualizado.CodigoAlerta);

            if (alertaExistente == null)
            {
               
                TAlertum[] lista = new TAlertum[]
                {
                    new("Alerta não encontrado.", 401, 0)

                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TAlerta.Any(a =>
                a.CodigoAlerta != alertaAtualizado.CodigoAlerta &&
                (a.DescricaoAlerta == alertaAtualizado.DescricaoAlerta ||
                 a.NivelAlerta == alertaAtualizado.NivelAlerta)))
            {
                PropertyInfo[] propriedades = typeof(TAlertum).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoAlerta" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TAlertum[] { alertaExistente };
            }
            else
            {
                TAlertum[] lista = new TAlertum[]
                {
                    new("Já existe um alerta com a mesmas Descrição.", 401, 0)

                };

                return lista;
            }
        }

        public async Task<TAlertum[]> Excluir(int CodigoAlerta)
        {
            var var = await _paineisContext.TAlerta.FindAsync(CodigoAlerta);

            if (var != null)
            {
                _paineisContext.TAlerta.Remove(var);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TAlertum[]> Incluir(TAlertum Alerta)
        {

            if (_paineisContext.TAlerta.Any(a => a.DescricaoAlerta == Alerta.DescricaoAlerta))
            {
                TAlertum[] lista = new TAlertum[]
                {
                    new("Já existe um alerta com a mesmas Descrição.", 401, 0)

                };

                return lista;
            }
            else if (_paineisContext.TAlerta.Any(a => a.NivelAlerta == Alerta.NivelAlerta))
            {
                TAlertum[] lista = new TAlertum[]
                {
                    new("Já existe um alerta com o mesmo Nivel de alerta.", 401, 0)

                };

                return lista;

            } else if (Alerta.NivelAlerta < 0) {

                TAlertum[] lista = new TAlertum[]
                {
                    new("O nível do alerta não pode ser menor que zero.", 401, 0)

                };

                return lista;
            }
            /*else if (_paineisContext.TAlerta.Any(a => a.CodigoCor == Alerta.CodigoCor))
            {
                TAlertum[] lista = new TAlertum[]
                                {
                    new("Já existe um alerta com a mesma Cor Alerta.", 401, 0)

                                };

                return lista;
            }*/
            else
            {
                _paineisContext.TAlerta.Add(Alerta);
                await _paineisContext.SaveChangesAsync();

                TAlertum[] lista = new TAlertum[]
                 {
                    new(Alerta.DescricaoAlerta, Alerta.NivelAlerta, Alerta.CodigoCor)
                 };

                return lista;
            }


            /*if (_paineisContext.TAlerta.Any(a => a.DescricaoAlerta == Alerta.DescricaoAlerta || a.NivelAlerta == Alerta.NivelAlerta || a.CodigoCor == Alerta.CodigoCor))
            {
                //throw new InvalidOperationException("Já existe um alerta com a mesmas informação.");
                TAlertum[] lista = new TAlertum[]
                {
                    new("Já existe um alerta com a mesmas informação.", 0, 0)

                };

                return lista;
            }
            else { 

                _paineisContext.TAlerta.Add(Alerta);
                await _paineisContext.SaveChangesAsync();
                TAlertum[] lista = new TAlertum[]
                 {
                    new(Alerta.DescricaoAlerta, Alerta.NivelAlerta, Alerta.CodigoCor)

                 };

                return lista;
            }*/
        }

        public async Task<TAlertum> SelecionarAsync(int CodigoAlerta)
        {
            return await _paineisContext.TAlerta.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoAlerta == CodigoAlerta);
        }

        public async Task<IEnumerable<TAlertum>> SelecionarTodosAsync()
        {
            return await _paineisContext.TAlerta.ToListAsync();
        }
    }
}
