using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Database;
using MoviesApi.Dtos.Movie;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public MovieController(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieDTO movieDTO)
        {

            MovieModel movie = _mapper.Map<MovieModel>(movieDTO);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListMovieById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<MovieViews> ListMovie()
        {
            IEnumerable<MovieModel> movie = _context.Movies.ToList();

            if (movie != null)
            {

                IEnumerable<MovieViews> movieViews = _mapper.Map<IEnumerable<MovieViews>>(movie);
                return movieViews.OrderBy(m => m.Title);
            }

            return null;
        }

        [HttpGet("{id}")]
        public IActionResult ListMovieById(int id)
        {

            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {

                MovieViews movieViews = _mapper.Map<MovieViews>(movie);
                return Ok(movieViews);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
        {

            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            _mapper.Map(movieDTO, movie);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {

            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
