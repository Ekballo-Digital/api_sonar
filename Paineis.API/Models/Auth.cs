using System.ComponentModel.DataAnnotations;

namespace Paineis.API.Models
{
    public class Auth
    {
        [Required (ErrorMessage = "Matricula é obrigatória")]
        public string MatriculaUsuario  { get; set; }
        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType (DataType.Password)]
        public string SenhaUsuario { get; set; }    
        

    }
}
