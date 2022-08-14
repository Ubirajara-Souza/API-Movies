using AutoMapper;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.Manager;
using MoviesApi.Domain.Entities;
using System.Linq;

namespace MoviesApi.Application.Mappers
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<ManagerDTO, ManagerModel>();
            CreateMap<ManagerModel, ManagerViews>()
                .ForMember(manager => manager.MovieTheater, opts => opts
                .MapFrom(manager => manager.MovieTheater.Select
                (m => new { m.Id, m.Name, m.Address, m.AddressID })));
        }

    }
}
