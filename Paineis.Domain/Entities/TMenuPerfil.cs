using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TMenuPerfil
    {
    
        public int CodigoPerfil { get; private set; }

        public int CodigoMenu { get; private set; }

        public virtual TMenu CodigoMenuNavigation { get; private set; } = null!;

        public virtual TPerfil CodigoPerfilNavigation { get; private set; } = null!;

        public TMenuPerfil(int CodigoPerfil, int codigoMenu)
        {
            ValidateDomain(CodigoPerfil, codigoMenu);
        }

        public void Update(int CodigoPerfil, int codigoMenu)
        {
            ValidateDomain(CodigoPerfil, codigoMenu);
            
        }

        private void ValidateDomain(int codigoPerfil, int codigoMenu)
        {
            //DomainExceptionValidation.When(codigoMenu <= 0, "O código do menu deve ser maior que zero.");
            CodigoPerfil = codigoPerfil;
            CodigoMenu = codigoMenu;
        }
    }
}