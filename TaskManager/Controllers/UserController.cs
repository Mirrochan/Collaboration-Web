using Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Contracts;

namespace TaskManager.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            await _userService.CreateUser(request.firstName, request.lastName, request.Email, request.passwordHash);
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var token = await _userService.Login(request.email, request.password);
            if (token == null)
                return Unauthorized();

            Response.Cookies.Append("tasty-cookies", token);
            return Ok(new { Token = token });
        }
    }
}   