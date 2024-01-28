using Microsoft.IdentityModel.Tokens;
using RealEstate.Core.Model;
using RealEstate.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RealEstate.WebAPI.Helper
{
    public class JWTGenerator
    {
        private readonly IConfiguration _configuration;
        public JWTGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string JwtToken(UserDTO user)
        {
            var claims = new[] {
                        new Claim(ClaimTypes.Role, "Admin")
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx")); //_configuration["Jwt:Key"]
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               "JWTAuthenticationServer",// _configuration["Jwt:Audience"],
                "JWTServicePostmanClient",  //_configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
