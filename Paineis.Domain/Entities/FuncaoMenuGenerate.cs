using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Entities
{
    public class FuncaoMenuGenerate
    {
        public int CodigoFuncao { get; set; }
        public string DescricaoFuncao { get; set; }

        public string? urlFuncao { get; set; }

        public string? iconSvg { get; set; }
    }
}
