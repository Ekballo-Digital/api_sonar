using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class FilaDTO
    {
        public int CodigoPainel { get; set; }
        public int CodigoFilaMsg { get; set; }
        public int FilaMsgAlerta { get; set; }
        public int FilaMsgPrioridade { get; set; }
        public string FilaMsgDesc { get; set; }
        public int FilaAreaCodigoEnvio { get; set; }
        public int FilaEnvioCodigo { get; set; }
        public string Matricula { get; set; }
        public int PainelEnvio { get; set; }
    }
}
