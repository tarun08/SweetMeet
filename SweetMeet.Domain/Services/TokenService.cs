using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SweetMeet.Domain.Entities;
using SweetMeet.Domain.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SweetMeet.Domain.Services
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        public string CreateToken(AppUser appUser)
        {
            var tokenKey = config["tokenKey"] ?? throw new Exception("Can't get token key.");

            if (tokenKey?.Length < 64)
                throw new Exception("Token key needs to be >= 64 characters.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, appUser.Email),
                new(ClaimTypes.NameIdentifier, appUser.PublicId.ToString()),
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
