using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class FuncaoDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string DescricaoFuncao { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string? UrlFuncao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string? IconSvg { get; set; }
    }
}
