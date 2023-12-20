using KotorsGate.Application.Security.Interfaces;
using KotorsGate.Application.Security.Models;
using KotorsGate.Application.Users.Interfaces;
using KotorsGate.Domain.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KotorsGate.WebApp.Controllers.Security
{
    public class UsersController : ApiControllerBase
    {
        private readonly IRegisterNewUser _registerNewUser;
        private readonly IFindOneUserById _findOneUserById;
        private readonly IGetCurrentUser _getCurrentUser;

        public UsersController(IRegisterNewUser registerNewUser,
                               IFindOneUserById findOneUserById,
                               IGetCurrentUser getCurrentUser) {
            _registerNewUser = registerNewUser;
            _findOneUserById = findOneUserById;
            _getCurrentUser = getCurrentUser;
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

        [Authorize]
        [HttpGet("authentication/{id}")]
        public async Task<ActionResult<UserAuth>> GetUserAuth(int id) {
            try {

                return await _getCurrentUser.GetAsync(id);

            } catch (Exception ex) {
                
                return BadRequest(ex.Message);
            }
        }
    }
}
