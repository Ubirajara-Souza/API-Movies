using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Database
{
    public class MoviesApiContext : DbContext
    {
        public MoviesApiContext(DbContextOptions<MoviesApiContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AddressModel>()
                .HasOne(address => address.MovieTheater)
                .WithOne(movieTheater => movieTheater.Address)
                .HasForeignKey<MovieTheaterModel>(movieTheater => movieTheater.AddressID);

            builder.Entity<MovieTheaterModel>()
                .HasOne(movieTheater => movieTheater.Manager)
                .WithMany(manager => manager.MovieTheater)
                .HasForeignKey(movieTheater => movieTheater.ManagerID); //.IsRequired(false); pode criar chave sem ser obrigatoria
                                                                        //.OnDelete(DeleteBehavior.Restrict); Propriedade usada quando for apagar dados inviduais das table.
            builder.Entity<SessionModel>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Session)
                .HasForeignKey(session => session.MovieID);

            builder.Entity<SessionModel>()
               .HasOne(session => session.MovieTheater)
               .WithMany(movieTheater => movieTheater.Session)
               .HasForeignKey(session => session.MovieTheaterID);
        }
        public DbSet<MovieModel> Movies { get; set; }

        public DbSet<MovieTheaterModel> MovieTheaters { get; set; }

        public DbSet<AddressModel> Address { get; set; }

        public DbSet<ManagerModel> Manager { get; set; }

        public DbSet<SessionModel> Session { get; set; }
    }
}

