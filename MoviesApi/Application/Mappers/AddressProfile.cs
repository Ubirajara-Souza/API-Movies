using AutoMapper;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.Address;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Application.Mappers
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDTO, AddressModel>();
            CreateMap<UpdateAddressDTO, AddressModel>();
            CreateMap<AddressModel, AddressViews>();
        }

    }
}
