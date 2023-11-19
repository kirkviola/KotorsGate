using KotorsGate.Application.Security.Entities;
using KotorsGate.Application.Security.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace KotorsGate.WebApp.Controllers.Security
{
    public class LoginController : ApiControllerBase
    {
        private IConfiguration _config;
        private IAuthenticateUser _authenticateUser;

        public LoginController(IConfiguration config, IAuthenticateUser authenticateUser) {
            _config = config;
            _authenticateUser = authenticateUser;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login) {
            if (await _authenticateUser.IsUserAsync(login)) {
                var tokenString = GenerateJSONWebToken();
                return Ok(new { token = tokenString });
            } else {
                return Unauthorized();
            }
        }

        private string GenerateJSONWebToken() {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
