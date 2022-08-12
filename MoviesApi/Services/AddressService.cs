using AutoMapper;
using FluentResults;
using MoviesApi.Database;
using MoviesApi.Dtos.Address;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Services
{
    public class AddressService
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public AddressService(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AddressViews AddAddress(AddressDTO addressDTO)
        {

            AddressModel address = _mapper.Map<AddressModel>(addressDTO);
            _context.Address.Add(address);
            _context.SaveChanges();

            return _mapper.Map<AddressViews>(address);
        }

        public IEnumerable<AddressViews> ListAddress()
        {
            IEnumerable<AddressModel> address = _context.Address;

            if (address != null)
            {
                IEnumerable<AddressViews> addressViews = _mapper.Map<IEnumerable<AddressViews>>(address);
                return addressViews;
            }

            return null;
        }

        public AddressViews ListAddressById(int id)
        {
            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                AddressViews addressViews = _mapper.Map<AddressViews>(address);
                return addressViews;
            }
            return null;
        }

        public Result UpdateAddress(int id, UpdateAddressDTO addressDTO)
        {
            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null)
            {
                return Result.Fail("Endereço Não encontrado");
            }

            _mapper.Map(addressDTO, address);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteAddress(int id)
        {
            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null)
            {
                return Result.Fail("Endereço Não encontrado");
            }

            _context.Remove(address);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
