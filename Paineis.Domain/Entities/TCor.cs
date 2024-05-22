using Paineis.Domain.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TCor
    {
        public TCor()
        {
            TAlerta = new HashSet<TAlertum>();
        }

        [Key]
        public int CodigoCor { get; private set; }

        public string DescricaoCor { get; private set; } = null!;

        public string HexaCor { get; private set; } = null!;

        public string HexaCorRed { get; private set; } = null!;

        public string HexaCorGreen { get; private set; } = null!;

        public string HexaCorBlue { get; private set; } = null!;


        public virtual ICollection<TAlertum> TAlerta { get; private set; }

        public TCor(string descricaoCor, string hexaCor, string hexaCorRed, string hexaCorGreen, string hexaCorBlue)
        {
            ValidateDomain(descricaoCor, hexaCor, hexaCorRed, hexaCorGreen, hexaCorBlue);
        }

        public void Update(string descricaoCor, string hexaCor, string hexaCorBlue, string hexaCorGreen, string hexaCorRed)
        {
            ValidateDomain(descricaoCor, hexaCor, hexaCorBlue, hexaCorGreen, hexaCorRed);
        }

        private void ValidateDomain(string descricaoCor, string hexaCor, string hexaCorRed, string hexaCorGreen, string hexaCorBlue)
        {
            //DomainExceptionValidation.When(string.IsNullOrEmpty(descricaoCor), "A descrição da cor é obrigatória.");
            //DomainExceptionValidation.When(string.IsNullOrEmpty(hexaCor), "O código hexadecimal da cor é obrigatório.");
            //DomainExceptionValidation.When(string.IsNullOrEmpty(hexaCorRed), "O código hexadecimal red da cor é obrigatório.");
            //DomainExceptionValidation.When(string.IsNullOrEmpty(hexaCorGreen), "O código hexadecimal green da cor é obrigatório.");
            //DomainExceptionValidation.When(string.IsNullOrEmpty(hexaCorBlue), "O código hexadecimal blue da cor é obrigatório.");


            DescricaoCor = descricaoCor;
            HexaCor = hexaCor; 
            HexaCorRed = hexaCorRed;
            HexaCorGreen = hexaCorGreen;
            HexaCorBlue = hexaCorBlue;

        }
    }
}