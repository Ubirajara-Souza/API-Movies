using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserApi.Domain.Dtos.Request.User;
using UserApi.Domain.Dtos.Response;
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

            return Ok(userDTO);
        }

        [HttpGet("{id}")]
        public IActionResult ListUserById(int id)
        {

            UserViews userViews = _userService.ListUserById(id);

            if (userViews != null)
                return Ok(userViews);

            return NotFound();
        }
    }
}
