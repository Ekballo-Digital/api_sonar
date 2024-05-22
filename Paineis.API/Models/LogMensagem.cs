using System.ComponentModel.DataAnnotations;

namespace Paineis.API.Models
{
    public class LogMensagem
    {
        public DateTime DataMsg { get; set; }
        public string MatriculaUsuarioMsg { get; set; }
        public int CodigoEstadoMsg { get; set; }
        public string DescricaoMsg { get; set; }
        public int CodigoAreaMsg { get; set; }
        public int CodigoStatusEnvioMsg { get; set; }
    }
}
