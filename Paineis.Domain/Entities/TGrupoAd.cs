using Paineis.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Paineis.Domain.Entities
{
    public partial class TGrupoAd
    {
        [Key] 
        public int CodigoGrupoAd { get; set; }
        public string NomeGrupoAd { get; set; } = null!;
        public int CodigoPerfil { get; set; }
        public int CodigoAreaGrupoAd { get; set; }


        public TGrupoAd(string nomeGrupoAd, int codigoPerfil, int codigoAreaGrupoAd)
        {
            ValidateDomain(nomeGrupoAd, codigoPerfil, codigoAreaGrupoAd);
        }

        public void Update(string nomeGrupoAd, int codigoPerfil, int codigoAreaGrupoAd)
        {
            ValidateDomain(nomeGrupoAd, codigoPerfil, codigoAreaGrupoAd);
        }

        public void ValidateDomain(string nomeGrupoAd, int codigoPerfil, int codigoAreaGrupoAd)
        {

            DomainExceptionValidation.When(nomeGrupoAd.Length < 10, "nomeGrupoAd menor que 10");
            DomainExceptionValidation.When(codigoPerfil < 0, "codigoPerfil não pode ser menor que zero");
            DomainExceptionValidation.When(codigoAreaGrupoAd < 0, "codigoAreaGrupoAd não pode ser menor que zero");

            NomeGrupoAd = nomeGrupoAd;
            CodigoPerfil = codigoPerfil;
            CodigoAreaGrupoAd = codigoAreaGrupoAd;
        }



        /*
        public virtual TArea CodigoAreaGrupoAdNavigation { get; set; } = null!;
        public virtual TPerfil CodigoPerfilNavigation { get; set; } = null!;*/
    }
}
