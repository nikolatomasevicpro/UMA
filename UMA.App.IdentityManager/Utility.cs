using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using UMA.App.Common.Configuration;
using UMA.App.IdentityManager.Authentication.Models;
using UMA.Infrastructure.Crypto;

namespace UMA.App.IdentityManager
{
    public static class Utility
    {
        public static bool FillToken(this BaseIdentityViewModel response, Domain.Identity.Identity identity)
        {

            try
            {
                //Convert roles to claims
                var claims = identity.IdentityRoles?.Select(x => new Claim(x.Role.Name, "1")).ToList() ?? new List<Claim>();

                //Supplementary details about the identity
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, identity.Login));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Sid, identity.Id.ToString()));

                //Fill query response
                //Basic identity info
                response.Id = identity.Id;
                response.Login = identity.Login;
                //This might be needed in controller logic
                response.Roles = identity.IdentityRoles?.Select(x => x.Role.Name).ToList() ?? new List<string>();
                //Authorization and authentication data
                response.Token = JWTTokenizer.GetToken(APIConfiguration.Intance.JwtConfig.Key, APIConfiguration.Intance.JwtConfig.Issuer, APIConfiguration.Intance.JwtConfig.Life, claims);
                response.Expires = DateTime.UtcNow + APIConfiguration.Intance.JwtConfig.Life;
                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
