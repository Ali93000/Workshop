using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Workshop.Entities.ApiModels.User.Response;
using Workshop.Entities.DTO.User;

namespace Workshop.Api.JWTImplementation
{
    public class TokenManager : ITokenManager
    {
        
        public string Secret = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";

        public string GenerateToken(UserDTO userLoginData)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            // Add Custom Claims
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("Id", userLoginData.Id);
            keyValuePairs.Add("Username", userLoginData.Username);
            keyValuePairs.Add("RoleId", userLoginData.RoleId);
            keyValuePairs.Add("RoleName", userLoginData.RoleName);
            keyValuePairs.Add("CompCode", userLoginData.CompCode);
            keyValuePairs.Add("BraCode", userLoginData.BraCode);
            keyValuePairs.Add("CompName", userLoginData.CompName);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                // Add Custom Claims
                Claims = keyValuePairs,
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, userLoginData.Username),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(Secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }

        public string ValidateToken(string token)
        {
            string username = null;
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;

                foreach (var claim in identity.Claims)
                {
                    if (!identity.HasClaim(claim.Type, claim.Value))
                        identity.AddClaim(claim);
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim.Value;
            return username;
        }


        // Read Token 
        // Must Return Privilages Class to use it in Insert
        public UserDTO ReadToken(string jwtToken)
        {
            //var jwt = Request.Headers.Authorization.Parameter;
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            System.IdentityModel.Tokens.Jwt.JwtSecurityToken token = handler.ReadJwtToken(jwtToken);
    
            IEnumerable<Claim> claims = token.Claims.ToList();

            string Id = token.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            string Username = token.Claims.FirstOrDefault(x => x.Type == "Username").Value;
            string RoleId = token.Claims.FirstOrDefault(x => x.Type == "RoleId").Value;
            string RoleName = token.Claims.FirstOrDefault(x => x.Type == "RoleName").Value;
            string CompCode = token.Claims.FirstOrDefault(x => x.Type == "CompCode").Value;
            string BraCode = token.Claims.FirstOrDefault(x => x.Type == "BraCode").Value;
            string CompName = token.Claims.FirstOrDefault(x => x.Type == "CompName").Value;
            UserDTO loginInfoResponse = new UserDTO()
            {
                Id = Convert.ToInt32(Id),
                Username = Username,
                RoleId = Convert.ToInt32(RoleId),
                RoleName = RoleName,
                CompCode = Convert.ToInt32(CompCode),
                CompName = CompName,
                BraCode = Convert.ToInt32(BraCode)
            };
            return loginInfoResponse;
        }

    }
}