using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserApi.Domain.Dtos.Request.Login;
using UserApi.Services;

namespace UserApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LoginUser([FromBody] LoginRequestDTO loginRequestDTO)
        {
            Result result = _loginService.LoginUser(loginRequestDTO);
            if (result.IsFailed)
                return Unauthorized(result.Errors.FirstOrDefault());

            return Ok(result.Successes.FirstOrDefault());
        }
    }
}
