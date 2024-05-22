using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class FuncaoMenuDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoMenu { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoFuncao { get; set; }
    }
}
