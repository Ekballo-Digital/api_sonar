using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class AlertaUpDTO
    {
        
        public int CodigoAlerta { get; set; }

        public string DescricaoAlerta { get; set; }
        
        public int NivelAlerta { get; set; }
        
        public int CodigoCor { get; set; }
       
    }
}
