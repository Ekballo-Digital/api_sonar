using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Infra.Ioc
{
    public static class ClaimsPrincipalExtension
    {

        public static int GetPerfil(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst("CodigoPerfil").Value);
        }

    }
}
