using Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Contracts;

namespace TaskManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService user) {
            _userService = user;
        }
        [HttpPost("users")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            await _userService.CreateUser(request.firstName, request.lastName, request.Email, request.passwordHash);
            return Ok();
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUser( Guid id)
        {
            var user = await _userService.GetUserById(id);
           return Ok(user);
        }

        public async Task<IActionResult> Login(IUserService service, UserLoginReguest reguest)
        {
            var token = await service.Login(reguest.email, reguest.password);
            return Ok(token);
        }
    }
}
