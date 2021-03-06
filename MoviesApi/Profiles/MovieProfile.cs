using AutoMapper;
using MoviesApi.Dtos.Movie;
using MoviesApi.Models;
using MoviesApi.Views;

namespace MoviesApi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDTO, MovieModel>();
            CreateMap<UpdateMovieDTO, MovieModel>();
            CreateMap<MovieModel, MovieViews>();
        }
    }
}
