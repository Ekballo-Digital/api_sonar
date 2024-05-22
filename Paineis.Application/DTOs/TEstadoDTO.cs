using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class TEstadoDTO
    {

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string DescricaoEstado { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoAreaEstado { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string TipoEstado { get; set; } = null!;
    }
}
