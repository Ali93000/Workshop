using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.DTO.User;

namespace Workshop.Api.JWTImplementation
{
    public interface ITokenManager
    {
        //string Secret { get; }
        string GenerateToken(UserDTO userLoginData);
        ClaimsPrincipal GetPrincipal(string token);
        string ValidateToken(string token);

        UserDTO ReadToken(string jwtToken);
    }
}
