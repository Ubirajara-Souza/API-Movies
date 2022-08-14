using AutoMapper;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.MovieTheater;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Application.Mappers
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<MovieTheaterDTO, MovieTheaterModel>();
            CreateMap<UpdateMovieTheaterDTO, MovieTheaterModel>();
            CreateMap<MovieTheaterModel, MovieTheaterViews>();
        }
    }
}
