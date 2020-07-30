using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Workshop.Api.JWTImplementation
{
    public class TokenManager : ITokenManager
    {
        
        public string Secret = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";

        public string GenerateToken(string username)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            // Add Custom Claims
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("id", "1");
            keyValuePairs.Add("role", "manager");
            keyValuePairs.Add("Compcode", "1");
            keyValuePairs.Add("Bracode", "1");

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                // Add Custom Claims
                Claims = keyValuePairs,
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, username),
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
        public void ReadToken(string jwtToken)
        {
            //var jwt = Request.Headers.Authorization.Parameter;
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            System.IdentityModel.Tokens.Jwt.JwtSecurityToken token = handler.ReadJwtToken(jwtToken);

            IEnumerable<Claim> claims = token.Claims.ToList();

            string id = token.Claims.FirstOrDefault(x => x.Type == "id").Value;
            string role = token.Claims.FirstOrDefault(x => x.Type == "role").Value;
            string Compcode = token.Claims.FirstOrDefault(x => x.Type == "Compcode").Value;
            string Bracode = token.Claims.FirstOrDefault(x => x.Type == "Bracode").Value;
        }

    }
}