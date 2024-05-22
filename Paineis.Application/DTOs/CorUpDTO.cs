using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class CorUpDTO
    {

        public int CodigoCor { get; set; }
        public string DescricaoCor { get; set; } = null!;
        public string HexaCor { get; set; } = null!;
        public string HexaCorRed { get; set; } = null!;
        public string HexaCorGreen { get; set; } = null!;
        public string HexaCorBlue { get; set; } = null!;
    }
}
