using KotorsGate.Application.Security.Interfaces;
using KotorsGate.Application.Users.Interfaces;
using KotorsGate.Domain.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KotorsGate.WebApp.Controllers.Security
{
    public class UsersController : ApiControllerBase
    {
        private IRegisterNewUser _registerNewUser;
        private IFindOneUserById _findOneUserById;

        public UsersController(IRegisterNewUser registerNewUser,
                               IFindOneUserById findOneUserById) {
            _registerNewUser = registerNewUser;
            _findOneUserById = findOneUserById;
        }

        [AllowAnonymous]
        [HttpPost("register")]
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

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id) {
            var user = await _findOneUserById.GetAsync(id);

            if (user == null) {
                return BadRequest();
            }

            return Ok(user);
        }
    }
}
