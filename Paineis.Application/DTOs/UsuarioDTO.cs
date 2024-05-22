using System.ComponentModel.DataAnnotations;

namespace Paineis.Application.DTOs
{
    public class UsuarioDTO
    {
        /*[Key]
        public int CodigoGrupoAd { get; set; }*/
        [Required (ErrorMessage = "Este campo e obrigatorio")]
        public string NomeGrupoAd { get; set; } = null!;
        [Required(ErrorMessage = "Este campo e obrigatorio")]
        public int CodigoPerfil { get; set; }
        [Required(ErrorMessage = "Este campo e obrigatorio")]
        public int CodigoAreaGrupoAd { get; set; }

    }
}
