using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class PerfilDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string NomePerfil { get; set; } = null!;
    }
}
