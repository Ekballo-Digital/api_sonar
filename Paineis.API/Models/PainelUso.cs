using System.ComponentModel.DataAnnotations;

namespace Paineis.API.Models
{
    public class PainelUso
    {
        [Required]
        public int CodigoPainel { get; set; }
    }
}
