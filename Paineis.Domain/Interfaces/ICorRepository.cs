using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Interfaces
{
    public interface ICorRepository
    {
        Task<TCor[]> Incluir(TCor Cor);
        Task<TCor[]> Alterar(TCor Cor);
        Task<TCor> Excluir(int CodigoCor);
        Task<TCor> SelecionarAsync(int CodigoCor);
        Task<IEnumerable<TCor>> SelecionarTodosAsync();
    }
}
