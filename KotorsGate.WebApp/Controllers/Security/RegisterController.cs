using KotorsGate.Application.Security.Interfaces;
using KotorsGate.Domain.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KotorsGate.WebApp.Controllers.Security
{
    public class RegisterController : ApiControllerBase
    {
        private IRegisterNewUser _registerNewUser;

        public RegisterController(IRegisterNewUser registerNewUser) {
            _registerNewUser = registerNewUser;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> RegisterNewUser(User user) {
            if (user == null) {
                return BadRequest();
            }

            try {
                var newUser = await _registerNewUser.RegisterAsync(user);
                return CreatedAtAction("GetUser", new { id =  user.Id }, user);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
