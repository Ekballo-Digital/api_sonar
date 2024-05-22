using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class AreaUpDTO
    {
        public int CodigoArea { get; set; }
        public string NomeArea { get; set; } = null!;
        public string SiglaArea { get; set; } = null!;
        public string TipoArea { get; set; } = null!;
    }
}
