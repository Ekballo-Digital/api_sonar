using Paineis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Account
{
    public interface IFuncaoMenuGenerate
    {
        Task<FuncaoMenuGenerate[]> FuncaoMenuGenerateAsync(int CodigoMenu);
    }
}
