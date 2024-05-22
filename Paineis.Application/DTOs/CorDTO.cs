using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class CorDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string DescricaoCor { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string HexaCor { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string HexaCorRed { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string HexaCorGreen { get; set; } = null!;  
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string HexaCorBlue { get; set; } = null!;
    }
}
