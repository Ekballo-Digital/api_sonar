using System.ComponentModel.DataAnnotations;

namespace Paineis.API.Models
{
    public class GenerateMenu
    {
        [Required]
        public string NomeGrupoAd { get; set; }
    }
}
