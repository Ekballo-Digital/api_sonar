using Paineis.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paineis.Domain.Entities
{
    public partial class TArea
    {
        public TArea()
        {
            TEstados = new HashSet<TEstado>();
            TPainels = new HashSet<TPainel>();
        }

        [Key]
        public int CodigoArea { get; private set; }

        public string NomeArea { get; private set; } = null!;

        public string SiglaArea { get; private set; } = null!;

        public string TipoArea { get; private set; } = null!;

        public virtual ICollection<TEstado> TEstados { get; private set; }

        public virtual ICollection<TPainel> TPainels { get; private set; }

        public TArea(string nomeArea, string siglaArea, string tipoArea)
        {
            ValidateDomain(nomeArea, siglaArea, tipoArea);
        }

        public void Update(string nomeArea, string siglaArea, string tipoArea)
        {
            ValidateDomain(nomeArea, siglaArea, tipoArea);
        }

        private void ValidateDomain(string nomeArea, string siglaArea, string tipoArea)
        {
            //DomainExceptionValidation.When(string.IsNullOrEmpty(nomeArea), "O nome da área é obrigatório.");
            //DomainExceptionValidation.When(string.IsNullOrEmpty(siglaArea), "A sigla da área é obrigatória.");
            //DomainExceptionValidation.When(string.IsNullOrEmpty(tipoArea), "O tipo da área é obrigatório.");

            NomeArea = nomeArea;
            SiglaArea = siglaArea;
            TipoArea = tipoArea;
        }
    }
}