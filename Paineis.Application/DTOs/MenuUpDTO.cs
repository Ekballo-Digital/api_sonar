using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class MenuUpDTO
    {

        public int CodigoMenu { get; set; }
        public string NomeMenu { get; set; } = null!;
        public string? UrlMenu { get; set; }
    }
}
