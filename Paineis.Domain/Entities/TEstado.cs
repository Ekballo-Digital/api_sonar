using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TEstado
    {
        [Key]
        public int CodigoEstado { get; private set; }

        public string DescricaoEstado { get; private set; } = null!;

        public int CodigoAreaEstado { get; private set; }

        public string TipoEstado { get; private set; } = null!;

        public virtual TArea CodigoAreaEstadoNavigation { get; private set; } = null!;

        public TEstado(string descricaoEstado, int codigoAreaEstado, string tipoEstado)
        {
            ValidateDomain(descricaoEstado, codigoAreaEstado, tipoEstado);
        }

        public void Update(string descricaoEstado, int codigoAreaEstado, string tipoEstado)
        {
            ValidateDomain(descricaoEstado, codigoAreaEstado, tipoEstado);
        }

        private void ValidateDomain(string descricaoEstado, int codigoAreaEstado, string tipoEstado)
        {
            //DomainExceptionValidation.When(string.IsNullOrEmpty(descricaoEstado), "A descrição do estado é obrigatória.");
            //DomainExceptionValidation.When(codigoAreaEstado <= 0, "O código da área do estado deve ser maior que zero.");
            //DomainExceptionValidation.When(string.IsNullOrEmpty(tipoEstado), "O tipo do estado é obrigatório.");

            DescricaoEstado = descricaoEstado;
            CodigoAreaEstado = codigoAreaEstado;
            TipoEstado = tipoEstado;
        }
    }
}