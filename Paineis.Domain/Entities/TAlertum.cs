using Microsoft.EntityFrameworkCore;
using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Paineis.Domain.Entities
{
    public partial class TAlertum
    {
        [Key]
        public int CodigoAlerta { get; private set; }
        public string DescricaoAlerta { get; set; }
        public int NivelAlerta { get; set; }
        public int CodigoCor { get; set; }

        public TAlertum(string descricaoAlerta, int nivelAlerta, int codigoCor)
        {
            ValidateDomain(descricaoAlerta, nivelAlerta, codigoCor);
        }

        public void Update(string descricaoAlerta, int nivelAlerta, int codigoCor)
        {
            ValidateDomain(descricaoAlerta, nivelAlerta, codigoCor);
        }

        private void ValidateDomain(string descricaoAlerta, int nivelAlerta, int codigoCor)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricaoAlerta), "A descrição do alerta é obrigatória.");
            //DomainExceptionValidation.When(nivelAlerta < 0, "O nível do alerta não pode ser menor que zero.");
            DomainExceptionValidation.When(codigoCor < 0, "O código da cor não pode ser menor que zero.");

            DescricaoAlerta = descricaoAlerta;
            NivelAlerta = nivelAlerta;
            CodigoCor = codigoCor;
        }

        public virtual TCor CodigoCorNavigation { get; set; } = null!;
    }
}