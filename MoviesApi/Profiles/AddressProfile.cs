using AutoMapper;
using MoviesApi.Dtos.Address;
using MoviesApi.Models;
using MoviesApi.Views;

namespace MoviesApi.Profiles
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
