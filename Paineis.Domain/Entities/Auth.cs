using Microsoft.EntityFrameworkCore;

namespace Paineis.Domain.Entities
{
    public partial class Auth
    {
        public List<dynamic> NomeGrupoAd { get; set; }
        public int CodigoPerfil { get; set; }
        public int CodigoAreaGrupoAd { get; set; }
        public string NomePerfil { get; set; }
        public string MatriculaUsuario { get; set; }
        public string NomeUsuario { get; set; }        
        public string Token { get; set; }
        public int StatusCode {  get; set; }

        public Auth()
        {
            // Inicialize a lista no construtor, para garantir que não seja nula
            NomeGrupoAd = new List<dynamic>();
        }
    }
}
