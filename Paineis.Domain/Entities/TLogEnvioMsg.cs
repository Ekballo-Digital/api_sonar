using System.ComponentModel.DataAnnotations.Schema;

namespace Paineis.Domain.Entities
{
    public partial class TLogEnvioMsg
    {
        public DateTime DataMsg { get; set; }
        public string MatriculaUsuarioMsg { get; set; }
        public int CodigoEstadoMsg { get; set; }
        public string DescricaoMsg { get; set; }
        public int CodigoAreaMsg { get; set; }
        public int CodigoStatusEnvioMsg { get; set; }
    }
}
