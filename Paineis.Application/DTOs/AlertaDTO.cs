using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class AlertaDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string DescricaoAlerta { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int NivelAlerta { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoCor { get; set; }
    }
}
