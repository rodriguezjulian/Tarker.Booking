using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.External;

namespace Tarker.Booking.External.GetTokenJWT
{
    public class GetTokenJwtService : IGetTokenJwtService
    {
        private readonly IConfiguration _configuration;
        public GetTokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Execute(string id) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string key = _configuration["SecretKeyJwt"] ?? "";
            var signingkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
                 new Claim(ClaimTypes.NameIdentifier, id)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Issuer"],
                Audience = _configuration["Audience"],
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
