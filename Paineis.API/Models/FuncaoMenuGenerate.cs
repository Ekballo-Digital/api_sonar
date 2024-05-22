using System.ComponentModel.DataAnnotations;

namespace Paineis.API.Models
{
    public class FuncaoMenuGenerate
    {
        [Required]
        public int CodigoMenu { get; set; }
    }
}
