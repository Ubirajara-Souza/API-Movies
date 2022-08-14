using AutoMapper;
using FluentResults;
using MoviesApi.Database;
using MoviesApi.Dtos.MovieTheater;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Services
{
    public class MovieTheaterService
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public MovieTheaterService(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovieTheaterViews AddMovieTheater(MovieTheaterDTO movieTheaterDTO)
        {

            MovieTheaterModel movieTheater = _mapper.Map<MovieTheaterModel>(movieTheaterDTO);
            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();

            return _mapper.Map<MovieTheaterViews>(movieTheater);
        }

        public IEnumerable<MovieTheaterViews> ListMovieTheater()
        {
            IEnumerable<MovieTheaterModel> movieTheater = _context.MovieTheaters;

            if (movieTheater != null)
            {
                IEnumerable<MovieTheaterViews> movieTheaterViews = _mapper.Map<IEnumerable<MovieTheaterViews>>(movieTheater);
                return movieTheaterViews.OrderBy(m => m.Name);
            }

            return null;
        }

        public MovieTheaterViews ListMovieTheaterById(int id)
        {
            MovieTheaterModel movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
            if (movieTheater != null)
            {
                MovieTheaterViews movieTheaterViews = _mapper.Map<MovieTheaterViews>(movieTheater);
                return movieTheaterViews;
            }
            return null;
        }

        public Result UpdateMovieTheater(int id, UpdateMovieTheaterDTO movieTheaterDTO)
        {

            MovieTheaterModel movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if (movieTheater == null)
            {
                return Result.Fail("Cinema Não encontrado");
            }

            _mapper.Map(movieTheaterDTO, movieTheater);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteMovieTheater(int id)
        {
            MovieTheaterModel movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if (movieTheater == null)
            {
                return Result.Fail("Cinema Não encontrado");
            }

            _context.Remove(movieTheater);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
