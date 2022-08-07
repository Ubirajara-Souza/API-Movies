using AutoMapper;
using MoviesApi.Dtos.Session;
using MoviesApi.Models;
using MoviesApi.Views;

namespace MoviesApi.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<SessionDTO, SessionModel>();
            CreateMap<SessionModel, SessionViews>()
                .ForMember(session => session.StartTime, opts => opts
                .MapFrom(session => session.ClosingTime.AddMinutes(session.Movie.Duration * (-1))));
        }
    }
}
