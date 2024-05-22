using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class TMatrizUpdateDTO
    {
        public int CodigoEstado { get; set; }

        public int CodigoArea { get; set; }

        public int CodigoAlerta { get; set; }

        public int CodigoPrioridade { get; set; }

        public int CodigoEstadoNovo { get; set; }

        public int CodigoAreaNovo { get; set; }

        public int CodigoAlertaNovo { get; set; }

        public int CodigoPrioridadeNovo { get; set; }
    }
}
