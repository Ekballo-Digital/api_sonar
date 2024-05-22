using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TMenu
    {
        [Key]
        public int CodigoMenu { get; private set; }

        public string NomeMenu { get; private set; } = null!;

        public string? UrlMenu { get; private set; }

        public TMenu(string nomeMenu, string urlMenu)
        {
            ValidateDomain(nomeMenu, urlMenu);
        }

        public void Update(string nomeMenu, string urlMenu)
        {
            ValidateDomain(nomeMenu, urlMenu);
            
        }

        private void ValidateDomain(string nomeMenu, string urlMenu)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeMenu), "O nome do menu é obrigatório.");
            NomeMenu = nomeMenu;
            UrlMenu = urlMenu;
        }
    }
}