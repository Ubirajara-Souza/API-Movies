using AutoMapper;
using MoviesApi.Dtos.MovieTheater;
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
