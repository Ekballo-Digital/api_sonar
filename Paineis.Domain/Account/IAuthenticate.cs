using Paineis.Domain.Entities;

namespace Paineis.Domain.Account
{
    public interface IAuthenticate
    {

        Task<Auth[]> AuthenticateAsync(string matricula, string senha);

        public string GenerateToken(string matricula, string senha, int CodigoPerfil);
    }
}
