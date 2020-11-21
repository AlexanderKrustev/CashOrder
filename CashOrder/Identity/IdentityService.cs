using Microsoft.AspNetCore.Identity;

namespace CashOrder.Identity
{

    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Models;
    public class IdentityService : IIdentityService
    {
        public string GenerateJwtToken(IdentityUser user, string secret)
        {               
            var key = Encoding.ASCII.GetBytes(secret);
         
            var tokenHandler = new JwtSecurityTokenHandler();
           
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    
    }
}
