using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class AreaDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string NomeArea { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string SiglaArea { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string TipoArea { get; set; } = null!;
    }
}
