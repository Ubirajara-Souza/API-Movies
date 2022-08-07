using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Database;
using MoviesApi.Dtos.Session;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Linq;

namespace MoviesApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public SessionController(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSession([FromBody] SessionDTO sessionDTO)
        {

            SessionModel session = _mapper.Map<SessionModel>(sessionDTO);

            _context.Session.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListSessionById), new { Id = session.Id }, session);
        }

        [HttpGet("{id}")]
        public IActionResult ListSessionById(int id)
        {

            SessionModel session = _context.Session.FirstOrDefault(session => session.Id == id);
            if (session != null)
            {

                SessionViews sessionViews = _mapper.Map<SessionViews>(session);
                return Ok(sessionViews);
            }
            return NotFound();
        }
    }
}
