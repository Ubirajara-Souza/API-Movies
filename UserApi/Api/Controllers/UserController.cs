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
            UserViews userViews = _userService.AddUser(userDTO);

            return CreatedAtAction(nameof(ListUserById), new { Id = userViews.Id }, userViews);
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
