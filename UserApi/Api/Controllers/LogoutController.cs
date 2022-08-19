using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UserApi.Services;

namespace UserApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult LogoutUser()
        {
            Result result = _logoutService.LogoutUser();
            if (result.IsFailed)
                return Unauthorized(result.Errors);

            return Ok(result.Successes);
        }
    }
}
