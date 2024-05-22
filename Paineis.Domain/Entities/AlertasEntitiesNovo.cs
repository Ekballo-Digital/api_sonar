using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Domain.Entities
{
    public class AlertasEntitiesNovo
    {
        public string? Mensagem { get; set; }

        public int CodigoArea { get; set; }

        public int? Alerta { get; set; }

        public int? Prioridade { get; set; }

        public string? Cor { get; set; }

        public int PainelEnvio { get; set; }
    }
}
