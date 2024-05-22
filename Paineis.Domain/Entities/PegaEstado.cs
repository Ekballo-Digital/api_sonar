using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Entities
{
    public class PegaEstado
    {
        public string DescricaoEstado { get; set; }
        public int NivelAlerta { get; set; }
        public int CodigoPrioridade { get; set; }
        public string DescCor { get; set; }
        public string SiglaArea { get; set; }
        public int CodigoArea { get; set; }
        public string TipoEstado { get; set; }
        public string Red { get; set; }
        public string Green { get; set; }
        public string Blue { get; set; }
    }
}
