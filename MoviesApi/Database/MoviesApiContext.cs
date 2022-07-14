using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Database
{
    public class MoviesApiContext : DbContext
    {
        public MoviesApiContext(DbContextOptions<MoviesApiContext> opt) : base(opt) { }

        public DbSet<MovieModel> Movies { get; set; }

        public DbSet<MovieTheaterModel> MovieTheaters { get; set; }
    }
}

