using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class MatrizDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoEstado { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoArea { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoAlerta { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoPrioridade { get; set; }
    }
}
