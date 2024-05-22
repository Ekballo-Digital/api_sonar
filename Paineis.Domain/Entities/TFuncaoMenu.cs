using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TFuncaoMenu
    {

        public int CodigoMenu { get; private set; }

        public int CodigoFuncao { get; private set; }

        public virtual TFuncao CodigoFuncaoNavigation { get; private set; } = null!;

        public virtual TMenu CodigoMenuNavigation { get; private set; } = null!;

        public TFuncaoMenu(int codigoMenu, int codigoFuncao)
        {
            ValidateDomain(codigoMenu, codigoFuncao);
        }

        public void Update(int codigoMenu, int codigoFuncao)
        {
            ValidateDomain(codigoMenu, codigoFuncao);
            
        }

        private void ValidateDomain(int codigoMenu, int codigoFuncao)
        {
            //DomainExceptionValidation.When(codigoFuncao <= 0, "O código da função deve ser maior que zero.");
            CodigoMenu = codigoMenu;
            CodigoFuncao = codigoFuncao;
        }
    }
}