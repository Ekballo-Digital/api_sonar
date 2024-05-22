using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class PainelDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string IpPainel { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoArea { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int PortaPainel { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int StatusPainel { get; set; }
    }
}
