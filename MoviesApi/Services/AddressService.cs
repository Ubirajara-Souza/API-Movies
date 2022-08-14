using AutoMapper;
using FluentResults;
using MoviesApi.Domain.Dtos.Response;
using MoviesApi.Domain.Dtos.Request.Address;
using MoviesApi.Domain.Entities;
using MoviesApi.Infra.Repositories;
using System.Collections.Generic;

namespace MoviesApi.Services
{
    public class AddressService
    {
        private AddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(AddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public AddressViews AddAddress(AddressDTO addressDTO)
        {

            AddressModel address = _mapper.Map<AddressModel>(addressDTO);
            _addressRepository.AddAddress(address);

            return _mapper.Map<AddressViews>(address);
        }

        public IEnumerable<AddressViews> ListAddress()
        {
            IEnumerable<AddressModel> address = _addressRepository.ListAddress();

            if (address != null)
            {
                IEnumerable<AddressViews> addressViews = _mapper.Map<IEnumerable<AddressViews>>(address);
                return addressViews;
            }

            return null;
        }

        public AddressViews ListAddressById(int id)
        {
            AddressModel address = _addressRepository.ListAddressById(id);
            if (address != null)
            {
                AddressViews addressViews = _mapper.Map<AddressViews>(address);
                return addressViews;
            }
            return null;
        }

        public Result UpdateAddress(int id, UpdateAddressDTO addressDTO)
        {
            AddressModel address = _addressRepository.ListAddressById(id);

            if (address == null)
            {
                return Result.Fail("Endereço Não encontrado");
            }

            _mapper.Map(addressDTO, address);
            _addressRepository.UpdateAddress(id, address);
            return Result.Ok();
        }

        public Result DeleteAddress(int id)
        {
            AddressModel address = _addressRepository.ListAddressById(id);

            if (address == null)
            {
                return Result.Fail("Endereço Não encontrado");
            }

            _addressRepository.DeleteAddress(id);
            return Result.Ok();
        }
    }
}
