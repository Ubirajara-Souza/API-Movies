using Microsoft.AspNetCore.Mvc;
using MoviesApi.Domain.Dtos.Request.Movie;
using MoviesApi.Services;
using System.Collections.Generic;
using FluentResults;
using MoviesApi.Domain.Dtos.Response;

namespace MoviesApi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieDTO movieDTO)
        {
            MovieViews movieViews = _movieService.AddMovie(movieDTO);

            return CreatedAtAction(nameof(ListMovieById), new { Id = movieViews.Id }, movieViews);
        }

        [HttpGet]
        public IActionResult ListMovie()
        {
            IEnumerable<MovieViews> movieViews = _movieService.ListMovie();

            if (movieViews != null)
                return Ok(movieViews);
            
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult ListMovieById(int id)
        {

            MovieViews movieViews = _movieService.ListMovieById(id);

            if (movieViews != null)
                return Ok(movieViews);

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
        {

            Result result = _movieService.UpdateMovie(id, movieDTO);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            Result result = _movieService.DeleteMovie(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
