using AutoMapper;
using FluentResults;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.Movie;
using MoviesApi.Domain.Entities;
using MoviesApi.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Services
{
    public class MovieService
    {
        private MovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(MovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public MovieViews AddMovie(MovieDTO movieDTO)
        {
            MovieModel movie = _mapper.Map<MovieModel>(movieDTO);
            _movieRepository.AddMovie(movie);
  
            return _mapper.Map<MovieViews>(movie);
        }

        public IEnumerable<MovieViews> ListMovie()
        {
            IEnumerable<MovieModel> movie = _movieRepository.ListMovie();

            if (movie != null)
            {
                IEnumerable<MovieViews> movieViews = _mapper.Map<IEnumerable<MovieViews>>(movie);
                return movieViews.OrderBy(m => m.Title);
            }

            return null;
        }

        public MovieViews ListMovieById(int id)
        {
            MovieModel movie = _movieRepository.ListMovieById(id);
            if (movie != null)
            {
                MovieViews movieViews = _mapper.Map<MovieViews>(movie);
                return movieViews;
            }
            return null;
        }

        public Result UpdateMovie(int id, UpdateMovieDTO movieDTO)
        {

            MovieModel movie = _movieRepository.ListMovieById(id);

            if (movie == null)
            {
                return Result.Fail("Filme Não encontrado");
            }

            _mapper.Map(movieDTO, movie);
            _movieRepository.UpdateMovie(id, movie);
            return Result.Ok();
        }

        public Result DeleteMovie(int id)
        {
            MovieModel movie = _movieRepository.ListMovieById(id);

            if (movie == null)
            {
                return Result.Fail("Filme Não encontrado");
            }

            _movieRepository.DeleteMovie(id);
            return Result.Ok();
        }
    }
}