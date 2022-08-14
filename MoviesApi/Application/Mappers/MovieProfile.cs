using AutoMapper;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.Movie;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Application.Mappers
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
