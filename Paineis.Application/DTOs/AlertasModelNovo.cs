using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class AlertasModelNovo
    {
        //[JsonProperty("mensagem")]
        public string? Mensagem { get; set; }
        //[JsonProperty("codigoArea")]
        public int CodigoArea { get; set; }
        //[JsonProperty("alerta")]
        public int? Alerta { get; set; }
        //[JsonProperty("prioridade")]
        public int? Prioridade { get; set; }
        //[JsonProperty("cor")]
        public string? Cor { get; set; }
        public int PainelEnvio { get; set;}
    }
}
