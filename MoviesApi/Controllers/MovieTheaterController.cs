using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Database;
using MoviesApi.Dtos.MovieTheater;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieTheaterController : ControllerBase
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public MovieTheaterController(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovieTheater([FromBody] MovieTheaterDTO movieTheaterDTO)
        {

            MovieTheaterModel movieTheater = _mapper.Map<MovieTheaterModel>(movieTheaterDTO);

            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListMovieTheaterById), new { Id = movieTheater.Id }, movieTheater);
        }

        [HttpGet]
        public IEnumerable<MovieTheaterViews> ListMovieTheater()
        {
            IEnumerable<MovieTheaterModel> movieTheater = _context.MovieTheaters.ToList();

            if (movieTheater != null)
            {

                IEnumerable<MovieTheaterViews> movieTheaterViews = _mapper.Map<IEnumerable<MovieTheaterViews>>(movieTheater);
                return movieTheaterViews.OrderBy(m => m.Name);
            }

            return null;
        }

        [HttpGet("{id}")]
        public IActionResult ListMovieTheaterById(int id)
        {

            MovieTheaterModel movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
            if (movieTheater != null)
            {

                MovieTheaterViews movieTheaterViews = _mapper.Map<MovieTheaterViews>(movieTheater);
                return Ok(movieTheaterViews);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDTO movieTheaterDTO)
        {

            MovieTheaterModel movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if (movieTheater == null)
            {
                return NotFound();
            }

            _mapper.Map(movieTheaterDTO, movieTheater);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieTheater(int id)
        {

            MovieTheaterModel movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if (movieTheater == null)
            {
                return NotFound();
            }

            _context.Remove(movieTheater);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
