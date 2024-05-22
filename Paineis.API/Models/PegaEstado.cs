using System.ComponentModel.DataAnnotations;

namespace Paineis.API.Models
{
    public class PegaEstado
    {
        [Required]
        public int CodigoEstado { get; set; }
    }
}
