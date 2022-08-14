using MoviesApi.Infra.Repositories.BaseContext;
using MoviesApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Infra.Repositories
{
    public class MovieTheaterRepository
    {
        protected readonly MoviesApiContext _context;

        public MovieTheaterRepository(MoviesApiContext context)
        {
            _context = context;
        }

        public MovieTheaterModel AddMovieTheater(MovieTheaterModel movieTheater)
        {
            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();

            return movieTheater;
        }

        public IEnumerable<MovieTheaterModel> ListMovieTheater()
        {
            return _context.MovieTheaters.ToList();
        }

        public MovieTheaterModel ListMovieTheaterById(int id)
        {
            MovieTheaterModel movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
            if (movieTheater != null)
            {
                return movieTheater;
            }
            return null;
        }

        public void UpdateMovieTheater(int id, MovieTheaterModel movieTheaterUpdate)
        {

            MovieTheaterModel movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if (movieTheater != null)
            {
                _context.SaveChanges();
            }

        }

        public void DeleteMovieTheater(int id)
        {
            MovieTheaterModel movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

            if (movieTheater != null)
            {
                _context.Remove(movieTheater);
                _context.SaveChanges();
            }
        }
    }
}
