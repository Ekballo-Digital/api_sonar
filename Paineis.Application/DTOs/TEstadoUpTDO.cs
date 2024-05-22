using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class TEstadoUpTDO
    {
        public int CodigoEstado { get; set; }
        public string DescricaoEstado { get; set; } = null!;
        public int CodigoAreaEstado { get; set; }
        public string TipoEstado { get; set; } = null!;
    }
}
