using Microsoft.AspNetCore.Mvc;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.Session;
using MoviesApi.Services;

namespace MoviesApi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private SessionService _sessionService;

        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public IActionResult AddSession([FromBody] SessionDTO sessionDTO)
        {
            SessionViews sessionViews = _sessionService.AddSession(sessionDTO);

            return CreatedAtAction(nameof(ListSessionById), new { Id = sessionViews.Id }, sessionViews);
        }

        [HttpGet("{id}")]
        public IActionResult ListSessionById(int id)
        {
            SessionViews sessionViews = _sessionService.ListSessionById(id);

            if (sessionViews != null)
                return Ok(sessionViews);

            return NotFound();
        }
    }
}
