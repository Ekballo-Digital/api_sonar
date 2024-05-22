using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Entities
{
    public partial class GenerateMenu
    {

        public int CodigoMenu { get; set; }
        public string NomeMenu { get; set; }
        public string? urlMenu { get; set; }
    }
}
