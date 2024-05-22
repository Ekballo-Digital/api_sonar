using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class MenuDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string NomeMenu { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string? UrlMenu { get; set; }
    }
}
