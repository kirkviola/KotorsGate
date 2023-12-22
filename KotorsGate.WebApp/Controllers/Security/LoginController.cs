using KotorsGate.Application.Exceptions;
using KotorsGate.Application.Interfaces;
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
        private readonly IConfiguration _config;
        private readonly IAuthenticateUser _authenticateUser;
        private readonly ISecurityService _securityService;

        public LoginController(IConfiguration config, IAuthenticateUser authenticateUser, ISecurityService securityService) {
            _config = config;
            _authenticateUser = authenticateUser;
            _securityService = securityService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login) {
            try {

                var user = await _authenticateUser.IsValidUserAsync(login);
                _securityService.SetCurrentUser(user.Id);
                var tokenString = GenerateJSONWebToken();
                return Ok(new { token = tokenString, user = user });

            } catch (Exception ex) {
                if (ex is InvalidLoginException) { 
                    return Unauthorized(ex.Message);
                } else {
                    return BadRequest(ex.Message);
                }
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
