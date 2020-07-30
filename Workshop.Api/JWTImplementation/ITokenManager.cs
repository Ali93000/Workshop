using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Api.JWTImplementation
{
    public interface ITokenManager
    {
        //string Secret { get; }
        string GenerateToken(string username);
        ClaimsPrincipal GetPrincipal(string token);
        string ValidateToken(string token);

        void ReadToken(string jwtToken);
    }
}
