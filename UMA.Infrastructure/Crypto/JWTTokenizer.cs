using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace UMA.Infrastructure.Crypto
{
    public static class JWTTokenizer
    {
        public static string GetToken(string key, string issuer, TimeSpan tokenLife, ICollection<Claim> claims = null)
        {
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer, 
                audience: issuer, 
                claims: claims, 
                expires: DateTime.UtcNow.Add(tokenLife),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
