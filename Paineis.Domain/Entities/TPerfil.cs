using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TPerfil
    {
        [Key]
        public int CodigoPerfil { get; private set; }

        public string NomePerfil { get; private set; } = null!;

        public TPerfil(string nomePerfil)
        {
            ValidateDomain(nomePerfil);
        }

        public void Update(string nomePerfil)
        {
            ValidateDomain(nomePerfil);
        }

        private void ValidateDomain(string nomePerfil)
        {
            //DomainExceptionValidation.When(string.IsNullOrEmpty(nomePerfil), "O nome do perfil é obrigatório.");
            NomePerfil = nomePerfil;
        }
    }
}