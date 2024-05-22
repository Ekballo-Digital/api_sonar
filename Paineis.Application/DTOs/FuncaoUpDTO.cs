using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class FuncaoUpDTO
    {
        public int CodigoFuncao { get; set; }
        public string DescricaoFuncao { get; set; } = null!;
        public string? UrlFuncao { get; set; }
        public string? IconSvg { get; set; }
    }
}
