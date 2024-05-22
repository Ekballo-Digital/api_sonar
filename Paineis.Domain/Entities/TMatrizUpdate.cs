using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Entities
{
    public class TMatrizUpdate
    {
        public int CodigoEstado { get; private set; }

        public int CodigoArea { get; private set; }

        public int CodigoAlerta { get; private set; }

        public int CodigoPrioridade { get; private set; }

        public int CodigoEstadoNovo { get; private set; }

        public int CodigoAreaNovo { get; private set; }

        public int CodigoAlertaNovo { get; private set; }

        public int CodigoPrioridadeNovo { get; private set; }
    }
}
