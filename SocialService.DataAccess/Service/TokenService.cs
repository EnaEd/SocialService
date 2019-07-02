using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SocialService.DataAccess.Entities;
using SocialService.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialService.DataAccess.Service
{
    public class TokenService : ITokenService
    {
        private UserManager<User> _userManager;
        private IConfiguration _configuration;
        public TokenService(UserManager<User> manager, IConfiguration configuration)
        {
            _userManager = manager;
            _configuration = configuration;
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
                    issuer: _configuration["AuthOption:Issuer"],
                    audience: _configuration["AuthOption:Audience"],
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(double.Parse(_configuration["AuthOption:LifeTime"]))),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AuthOption:Key"])), SecurityAlgorithms.HmacSha256));
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

