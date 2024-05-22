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
    public class FuncaoSistemaRepository : IFuncaoSistemaRepository
    {
        private readonly PAINEISContext _paineisContext;

        public FuncaoSistemaRepository(PAINEISContext context)
        {
            _paineisContext = context;
        }

        public async Task<TFuncao[]> Alterar(TFuncao alertaAtualizado)

        {
            Console.WriteLine(alertaAtualizado);
            TFuncao alertaExistente = await _paineisContext.TFuncaos.FirstOrDefaultAsync(a => a.CodigoFuncao == alertaAtualizado.CodigoFuncao);

            if (alertaExistente == null)
            {

                TFuncao[] lista = new TFuncao[]
                {
                    new("Função não encontrado.", "401", null)

                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TFuncaos.Any(a =>
                a.CodigoFuncao != alertaAtualizado.CodigoFuncao &&
                (a.DescricaoFuncao == alertaAtualizado.DescricaoFuncao ||
                 a.UrlFuncao == alertaAtualizado.UrlFuncao || string.IsNullOrEmpty(alertaAtualizado.IconSvg))))
            {
                PropertyInfo[] propriedades = typeof(TFuncao).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoFuncao" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TFuncao[] { alertaExistente };
            }
            else
            {
                TFuncao[] lista = new TFuncao[]
                {
                    new("Já existe um função com a mesmas Descrição ou svg vazio.", "401", null)

                };

                return lista;
            }

        }

        public async Task<TFuncao> Excluir(int CodigoFuncao)
        {
            var var = await _paineisContext.TFuncaos.FindAsync(CodigoFuncao);

            if (var != null)
            {
                _paineisContext.TFuncaos.Remove(var);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TFuncao[]> Incluir(TFuncao Funcao)
        {

            if (_paineisContext.TFuncaos.Any(a => a.DescricaoFuncao == Funcao.DescricaoFuncao))
            {
                TFuncao[] lista = new TFuncao[] {
                    new("Já existe um função com a mesmas Descrição.", "401", null)
                };
           

                return lista;
            }
            else if (_paineisContext.TFuncaos.Any(a => a.UrlFuncao == Funcao.UrlFuncao))
            {
                TFuncao[] lista = new TFuncao[]
                {
                     new("Já existe uma função com a mesmas url.", "401", null)

                };

                return lista;

            }
            else if (string.IsNullOrEmpty(Funcao.IconSvg))
            {
                TFuncao[] lista = new TFuncao[]
                {
                     new("Já svg e obrigatorio.", "401", null)

                };

                return lista;

            }
            else
            {
                _paineisContext.TFuncaos.Add(Funcao);
                await _paineisContext.SaveChangesAsync();

                TFuncao[] lista = new TFuncao[]
                 {
                    new(Funcao.DescricaoFuncao, Funcao.UrlFuncao, Funcao.IconSvg)
                 };

                return lista;
            }

        }

        public async Task<TFuncao> SelecionarAsync(int CodigoFuncao)
        {
            return await _paineisContext.TFuncaos.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoFuncao == CodigoFuncao);
        }

        public async Task<IEnumerable<TFuncao>> SelecionarTodosAsync()
        {
            return await _paineisContext.TFuncaos.ToListAsync();
        }
    }
}
