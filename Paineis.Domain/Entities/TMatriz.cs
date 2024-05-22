using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TMatriz
    {
        
        public int CodigoEstado { get; private set; }

        public int CodigoArea { get; private set; }

        public int CodigoAlerta { get; private set; }

        public int CodigoPrioridade { get; private set; }

        public TMatriz(int codigoEstado, int codigoArea, int codigoAlerta, int codigoPrioridade)
        {
            ValidateDomain(codigoEstado, codigoArea, codigoAlerta, codigoPrioridade);
        }

        public virtual TAlertum CodigoAlertaNavigation { get; private set; } = null!;

        public virtual TArea CodigoAreaNavigation { get; private set; } = null!;

        public virtual TEstado CodigoEstadoNavigation { get; private set; } = null!;

        public virtual TPrioridade CodigoPrioridadeNavigation { get; private set; } = null!;

        public void Update(int codigoEstado, int codigoArea, int codigoAlerta, int codigoPrioridade)
        {
            ValidateDomain(codigoEstado, codigoArea, codigoAlerta, codigoPrioridade);

        }

        private void ValidateDomain(int codigoEstado, int codigoArea, int codigoAlerta, int codigoPrioridade)
        {
            /*DomainExceptionValidation.When(codigoArea <= 0, "O código da área deve ser maior que zero.");
            DomainExceptionValidation.When(codigoAlerta <= 0, "O código do alerta deve ser maior que zero.");
            DomainExceptionValidation.When(codigoPrioridade <= 0, "O código da prioridade deve ser maior que zero.");*/

            CodigoEstado = codigoEstado;
            CodigoArea = codigoArea;
            CodigoAlerta = codigoAlerta;
            CodigoPrioridade = codigoPrioridade;
        }
    }
}