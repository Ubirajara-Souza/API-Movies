using AutoMapper;
using MoviesApi.Dtos;
using MoviesApi.Models;
using MoviesApi.Views;

namespace MoviesApi.Profiles
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
