using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTOs
{
    public class PrioridadeUpDTO
    {
        public int CodigoPrioridade { get; set; }
        
        public string NomePrioridade { get; set; } = null!;
    }
}
