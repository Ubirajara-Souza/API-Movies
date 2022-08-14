using MoviesApi.Infra.Repositories.BaseContext;
using MoviesApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Infra.Repositories
{
    public class MovieRepository
    {
        protected readonly MoviesApiContext _context;

        public MovieRepository(MoviesApiContext context)
        {
            _context = context;
        }

        public MovieModel AddMovie(MovieModel movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        public IEnumerable<MovieModel> ListMovie()
        {
            return _context.Movies.ToList();
        }

        public MovieModel ListMovieById(int id)
        {
            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                return movie;
            }
            return null;
        }

        public void UpdateMovie(int id, MovieModel movieUpdate)
        {

            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie != null)
            {
                _context.SaveChanges();
            }

        }

        public void DeleteMovie(int id)
        {
            MovieModel movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie != null)
            {
                _context.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
