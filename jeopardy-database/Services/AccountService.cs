using System.Security.Claims;
using jeopardy.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace jeopardy.Services {
    public class AccountService {
        private IConfiguration _config;
        public AccountService (IConfiguration config) {
            _config = config;
        }
        public string Login(LoginDTO login) {
            
            var claims = new Claim[] {
                new Claim (ClaimTypes.NameIdentifier, login.username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(20),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])), SecurityAlgorithms.HmacSha256
                )
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}