using AutoMapper;
using FluentResults;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.MovieTheater;
using MoviesApi.Domain.Entities;
using MoviesApi.Infra.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Services
{
    public class MovieTheaterService
    {
        private MovieTheaterRepository _movieTheaterRepository;
        private readonly IMapper _mapper;

        public MovieTheaterService(MovieTheaterRepository movieTheaterRepository, IMapper mapper)
        {
            _movieTheaterRepository = movieTheaterRepository;
            _mapper = mapper;
        }

        public MovieTheaterViews AddMovieTheater(MovieTheaterDTO movieTheaterDTO)
        {

            MovieTheaterModel movieTheater = _mapper.Map<MovieTheaterModel>(movieTheaterDTO);
            _movieTheaterRepository.AddMovieTheater(movieTheater);

            return _mapper.Map<MovieTheaterViews>(movieTheater);
        }

        public IEnumerable<MovieTheaterViews> ListMovieTheater()
        {
            IEnumerable<MovieTheaterModel> movieTheater = _movieTheaterRepository.ListMovieTheater();

            if (movieTheater != null)
            {
                IEnumerable<MovieTheaterViews> movieTheaterViews = _mapper.Map<IEnumerable<MovieTheaterViews>>(movieTheater);
                return movieTheaterViews.OrderBy(m => m.Name);
            }

            return null;
        }

        public MovieTheaterViews ListMovieTheaterById(int id)
        {
            MovieTheaterModel movieTheater = _movieTheaterRepository.ListMovieTheaterById(id);
            if (movieTheater != null)
            {
                MovieTheaterViews movieTheaterViews = _mapper.Map<MovieTheaterViews>(movieTheater);
                return movieTheaterViews;
            }
            return null;
        }

        public Result UpdateMovieTheater(int id, UpdateMovieTheaterDTO movieTheaterDTO)
        {

            MovieTheaterModel movieTheater = _movieTheaterRepository.ListMovieTheaterById(id);

            if (movieTheater == null)
            {
                return Result.Fail("Cinema Não encontrado");
            }

            _mapper.Map(movieTheaterDTO, movieTheater);
            _movieTheaterRepository.UpdateMovieTheater(id, movieTheater);
            return Result.Ok();
        }

        public Result DeleteMovieTheater(int id)
        {
            MovieTheaterModel movieTheater = _movieTheaterRepository.ListMovieTheaterById(id);

            if (movieTheater == null)
            {
                return Result.Fail("Cinema Não encontrado");
            }

            _movieTheaterRepository.DeleteMovieTheater(id);
            return Result.Ok();
        }
    }
}
