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
    public class CorRepository : ICorRepository
    {

        private readonly PAINEISContext _paineisContext;

        public CorRepository(PAINEISContext context)
        {
            _paineisContext = context;
        }

        public async Task<TCor[]> Alterar(TCor alertaAtualizado)
        {
            TCor alertaExistente = await _paineisContext.TCors.FirstOrDefaultAsync(a => a.CodigoCor == alertaAtualizado.CodigoCor);

            if (alertaExistente == null)
            {

                TCor[] lista = new TCor[]
                {
                     new("Alerta não encontrado.", "401", "", "", "")

                };

                return lista;
            }

            // Verifica se os valores das propriedades são diferentes dos valores existentes no banco de dados
            if (!_paineisContext.TCors.Any(a =>
                a.CodigoCor != alertaAtualizado.CodigoCor &&
                (a.DescricaoCor == alertaAtualizado.DescricaoCor ||
                 a.HexaCor == alertaAtualizado.HexaCor)))
            {
                PropertyInfo[] propriedades = typeof(TCor).GetProperties();

                foreach (PropertyInfo propriedade in propriedades)
                {
                    // Verifica se a propriedade é editável (não é a chave primária)
                    if (propriedade.Name != "CodigoCor" && propriedade.CanWrite)
                    {
                        // Obtém o valor atualizado da propriedade do objeto atualizado
                        object valorAtualizado = propriedade.GetValue(alertaAtualizado);

                        // Define o valor atualizado da propriedade no objeto existente
                        propriedade.SetValue(alertaExistente, valorAtualizado);
                    }
                }

                await _paineisContext.SaveChangesAsync();

                // Retorna o objeto atualizado como um array para compatibilidade com o código existente
                return new TCor[] { alertaExistente };
            }
            else
            {
                TCor[] lista = new TCor[]
                {
                   new("Já existe uma cor com a mesmas Descrição.", "401", "", "", "")

                };

                return lista;
            }

            /*_paineisContext.TCors.Update(Cor);
            await _paineisContext.SaveChangesAsync();
            return Cor;*/
        }

        public async Task<TCor> Excluir(int CodigoCor)
        {
            var var = await _paineisContext.TCors.FindAsync(CodigoCor);

            if (var != null)
            {
                _paineisContext.TCors.Remove(var);
                await _paineisContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<TCor[]> Incluir(TCor Cor)
        {


            if (_paineisContext.TCors.Any(a => a.DescricaoCor == Cor.DescricaoCor))
            {
                TCor[] lista = new TCor[]
                {
                    new("Já existe uma cor com a mesmas Descrição.", "401", "", "", "")

                };

                return lista;

            }else if (_paineisContext.TCors.Any(a => a.HexaCor == Cor.HexaCor))
            {
                TCor[] lista = new TCor[]
               {
                    new("Já existe um HexaCor com a mesmas Descrição.", "401", "", "", "")

               };

                return lista;

            }
            else
            {

                _paineisContext.TCors.Add(Cor);
                await _paineisContext.SaveChangesAsync();


                TCor[] lista = new TCor[]
                 {
                    new(Cor.DescricaoCor, Cor.HexaCor, Cor.HexaCorRed, Cor.HexaCorGreen, Cor.HexaCorBlue)
                 };

                return lista;
            }

        }

        public async Task<TCor> SelecionarAsync(int CodigoCor)
        {
            return await _paineisContext.TCors.AsNoTracking().FirstOrDefaultAsync(x => x.CodigoCor == CodigoCor);
        }

        public async Task<IEnumerable<TCor>> SelecionarTodosAsync()
        {
            return await _paineisContext.TCors.ToListAsync();
        }
    }
}
