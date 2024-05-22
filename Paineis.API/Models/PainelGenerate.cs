using System.ComponentModel.DataAnnotations;

namespace Paineis.API.Models
{
    public class PainelGenerate
    {
        [Required]
        public string NomeGrupoAd { get; set; }
    }
}
