using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserApi.Domain.Dtos.Request.User;
using UserApi.Services;

namespace UserApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDTO userDTO)
        {
            Result result = _userService.AddUser(userDTO);
            if (result.IsFailed)
                return StatusCode(500);

            return Ok(result.Successes.FirstOrDefault());
        }

        [HttpGet("/active")]  
        public IActionResult ActiveAccountUser([FromQuery] ActiveAccountUserDTO activeAccountUserDTO)
        {
            Result result = _userService.ActiveAccountUser(activeAccountUserDTO);
            if (result.IsFailed)
                return StatusCode(500);

            return Ok(result.Successes);
        }
    }
}
