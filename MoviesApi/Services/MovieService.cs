using AutoMapper;
using FluentResults;
using MoviesApi.Database;
using MoviesApi.Dtos.Movie;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Services
{
    public class MovieService
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public MovieService(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovieViews AddMovie(MovieDTO movieDTO)
        {

            MovieModel movie = _mapper.Map<MovieModel>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return _mapper.Map<MovieViews>(movie);
        }

        public IEnumerable<MovieViews> ListMovie()
        {
            IEnumerable<MovieModel> movie = _context.Movies;

            if (movie != null)
            {
                IEnumerable<MovieViews> movieViews = _mapper.Map<IEnumerable<MovieViews>>(movie);
                return movieViews.OrderBy(m => m.Title);
            }

            return null;
        }

        public MovieViews ListMovieById(int id)
        {
            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                MovieViews movieViews = _mapper.Map<MovieViews>(movie);
                return movieViews;
            }
            return null;
        }

        public Result UpdateMovie(int id, UpdateMovieDTO movieDTO)
        {

            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
            {
                return Result.Fail("Filme Não encontrado");
            }

            _mapper.Map(movieDTO, movie);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteMovie(int id)
        {
            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
            {
                return Result.Fail("Filme Não encontrado");
            }

            _context.Remove(movie);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}