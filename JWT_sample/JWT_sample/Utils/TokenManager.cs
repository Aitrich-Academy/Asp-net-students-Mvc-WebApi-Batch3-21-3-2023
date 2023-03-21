using JWT_sample.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace JWT_sample.Utils
{
    public class TokenManager
    {
        private static string Secret = "ERMN05OPLoDvbTTa/QkqLNMI3cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";

        public static string GenerateToken(UsersDTO UsersBO)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            int TokenExpiry = int.Parse(ConfigurationManager.AppSettings["TokenExpiry"]);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Issuer = "MyProjectName",
                Subject = new ClaimsIdentity(
                    new[] {
                        new Claim("id", UsersBO.Id.ToString()),
                        new Claim("role", UsersBO.Role.ToString())
                    }),
                Expires = DateTime.UtcNow.AddMinutes(TokenExpiry),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }

        public static UsersDTO ValidateToken(string token)
        {
            ClaimsPrincipal principal = GetPrincipal(token);
            return GetUserFromPrincipal(principal);
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null) return null;
                byte[] key = Convert.FromBase64String(Secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero //validity not checking
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);

                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");
                return principal;
            }
            catch
            {
                return null;
            }
        }

        private static UsersDTO GetUserFromPrincipal(ClaimsPrincipal principal)
        {
            if (principal == null) return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim userpidClaim = identity.FindFirst("id");
            Claim usertypeClaim = identity.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            UsersDTO usersDTO = new UsersDTO
            {
                Id =int.Parse( userpidClaim.Value),
                Role = usertypeClaim.Value
            };
            return usersDTO;
        }

    }
}