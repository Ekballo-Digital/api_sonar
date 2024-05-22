using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class TGrupoAdUpDTO
    {
        public int CodigoGrupoAd { get; set; }
        public string NomeGrupoAd { get; set; } = null!;
        public int CodigoPerfil { get; set; }
        public int CodigoAreaGrupoAd { get; set; }
    }
}
