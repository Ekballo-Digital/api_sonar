using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Account
{
    public interface IGeneratePainel
    {
        Task<GeneratePainel[]> GeneratePainelAsync(string NomeGrupoAd);
    }
}
