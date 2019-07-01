using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SocialService.DataAccess.Auth;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialService.DataAccess.Service
{
    public class TokenService : ITokenService
    {
        private UserManager<User> _userManager;
        public TokenService(UserManager<User> manager)
        {
            _userManager = manager;
        }
        public async Task<string> GetToken(string username, string userPassword)
        {
            ClaimsIdentity identity = await GetIdentity(username, userPassword);
            if (identity is null)
            {
                return string.Empty;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            string token = JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return token;
        }

        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            User user = await _userManager.FindByEmailAsync(username);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
                    
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims: claims, authenticationType: "Token", nameType: ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}

