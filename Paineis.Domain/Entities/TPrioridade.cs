using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TPrioridade
    {
        [Key]
        public int CodigoPrioridade { get; private set; }

        public string NomePrioridade { get; private set; } = null!;

        public TPrioridade(int codigoPrioridade, string nomePrioridade)
        {
            ValidateDomain(codigoPrioridade, nomePrioridade);
        }

        public void Update(int codigoPrioridade, string nomePrioridade)
        {
            ValidateDomain(codigoPrioridade, nomePrioridade);
            
        }

        private void ValidateDomain(int codigoPrioridade, string nomePrioridade)
        {
            //DomainExceptionValidation.When(string.IsNullOrEmpty(nomePrioridade), "O nome da prioridade é obrigatório.");
            CodigoPrioridade = codigoPrioridade;
            NomePrioridade = nomePrioridade;
        }
    }
}