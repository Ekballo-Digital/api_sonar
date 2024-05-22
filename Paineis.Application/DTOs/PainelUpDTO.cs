using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class PainelUpDTO
    {
        public int CodigoPainel { get; set; }
        public string IpPainel { get; set; } = null!;
        public int CodigoArea { get; set; }
        public int PortaPainel { get; set; }
        public int StatusPainel { get; set; }
    }
}
