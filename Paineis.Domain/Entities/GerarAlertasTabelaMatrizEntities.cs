using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Entities
{
    public class GerarAlertasTabelaMatrizEntities
    {
        public int NivelAlerta { get; set; }
        public string Red { get; set; }
        public string Green { get; set; }
        public string Blue { get; set; }
        public int CodigoPrioridade { get; set; }
        public string TipoEstado { get; set; }
    }
}
