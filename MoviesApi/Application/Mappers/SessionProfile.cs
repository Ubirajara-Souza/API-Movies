using AutoMapper;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.Session;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Application.Mappers
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<SessionDTO, SessionModel>();
            CreateMap<SessionModel, SessionViews>()
            .ForMember(session => session.StartTime, opts => opts
            .MapFrom(session => session.ClosingTime.AddMinutes(240 * (-1))));
            //AddMinutes(session.Movie.Duration * (-1)))
        }
    }
}
