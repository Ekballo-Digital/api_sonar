using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TFuncao
    {
        [Key]
        public int CodigoFuncao { get; private set; }

        public string DescricaoFuncao { get; private set; } = null!;

        public string? UrlFuncao { get; private set; }

        public string? IconSvg { get; private set; }

        public TFuncao(string DescricaoFuncao, string UrlFuncao, string IconSvg) {
            ValidateDomain(DescricaoFuncao, UrlFuncao, IconSvg);
        }

        public void Update(string descricaoFuncao, string urlFuncao, string iconSvg)
        {
            ValidateDomain(DescricaoFuncao, UrlFuncao, IconSvg);
            
        }

        private void ValidateDomain(string descricaoFuncao, string urlFuncao, string iconSvg)
        {
            //DomainExceptionValidation.When(string.IsNullOrEmpty(descricaoFuncao), "A descrição da função é obrigatória.");
            DescricaoFuncao = descricaoFuncao;
            UrlFuncao = urlFuncao;
            IconSvg = iconSvg;
        }
    }
}