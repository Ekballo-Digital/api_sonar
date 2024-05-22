using System.ComponentModel.DataAnnotations;

namespace Paineis.Application.DTOs
{
    public class TGrupoAdDTO
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string NomeGrupoAd { get; set; } = null!;
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoPerfil { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int CodigoAreaGrupoAd { get; set; }
    }
}
