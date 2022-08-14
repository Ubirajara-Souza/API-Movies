using Microsoft.AspNetCore.Mvc;
using MoviesApi.Dtos.MovieTheater;
using MoviesApi.Views;
using System.Collections.Generic;
using FluentResults;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieTheaterController : ControllerBase
    {
        private MovieTheaterService _movieTheaterService;

        public MovieTheaterController(MovieTheaterService movieTheaterService)
        {
            _movieTheaterService = movieTheaterService;
        }

        [HttpPost]
        public IActionResult AddMovieTheater([FromBody] MovieTheaterDTO movieTheaterDTO)
        {
            MovieTheaterViews movieTheaterViews = _movieTheaterService.AddMovieTheater(movieTheaterDTO);

            return CreatedAtAction(nameof(ListMovieTheaterById), new { Id = movieTheaterViews.Id }, movieTheaterViews);

        }

        [HttpGet]
        public IActionResult ListMovieTheater()
        {
            IEnumerable<MovieTheaterViews> movieTheaterViews = _movieTheaterService.ListMovieTheater();

            if (movieTheaterViews != null)
                return Ok(movieTheaterViews);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult ListMovieTheaterById(int id)
        {
            MovieTheaterViews movieTheaterViews = _movieTheaterService.ListMovieTheaterById(id);

            if (movieTheaterViews != null)
                return Ok(movieTheaterViews);

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDTO movieTheaterDTO)
        {
            Result result = _movieTheaterService.UpdateMovieTheater(id, movieTheaterDTO);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieTheater(int id)
        {
            Result result = _movieTheaterService.DeleteMovieTheater(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
