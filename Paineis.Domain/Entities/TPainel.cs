using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TPainel
    {
        [Key]
        public int CodigoPainel { get; private set; }

        public string IpPainel { get; private set; } = null!;

        public int CodigoArea { get; private set; }

        public int PortaPainel { get; private set; }

        public int StatusPainel { get; private set; }

        public virtual TArea CodigoAreaNavigation { get; private set; } = null!;

        public TPainel(string ipPainel, int codigoArea, int portaPainel, int statusPainel)
        {
            ValidateDomain(ipPainel, codigoArea, portaPainel, statusPainel);
        }

        public void Update(string ipPainel, int codigoArea, int portaPainel, int statusPainel)
        {
            ValidateDomain(ipPainel, codigoArea, portaPainel, statusPainel);
            
        }

        private void ValidateDomain(string ipPainel, int codigoArea, int portaPainel, int statusPainel)
        {
            //DomainExceptionValidation.When(string.IsNullOrEmpty(ipPainel), "O IP do painel é obrigatório.");
            //DomainExceptionValidation.When(codigoArea <= 0, "O código da área deve ser maior que zero.");
            //DomainExceptionValidation.When(portaPainel <= 0, "A porta do painel deve ser maior que zero.");
            //DomainExceptionValidation.When(statusPainel != 1 || statusPainel != 0, "O status do painel não pode ser diferente de 1 ou 0.");
            IpPainel = ipPainel;
            CodigoArea = codigoArea;
            PortaPainel = portaPainel;
            StatusPainel = statusPainel;
        }
    }
}