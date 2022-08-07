using AutoMapper;
using MoviesApi.Dtos.Manager;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Linq;

namespace MoviesApi.Profiles
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
