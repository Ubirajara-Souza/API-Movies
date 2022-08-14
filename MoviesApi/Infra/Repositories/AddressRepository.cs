using MoviesApi.Infra.Repositories.BaseContext;
using MoviesApi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Infra.Repositories
{
    public class AddressRepository
    {
        protected readonly MoviesApiContext _context;

        public AddressRepository(MoviesApiContext context)
        {
            _context = context;
        }

        public AddressModel AddAddress(AddressModel address)
        {
            _context.Address.Add(address);
            _context.SaveChanges();

            return address;
        }

        public IEnumerable<AddressModel> ListAddress()
        {
            return _context.Address.ToList();
        }

        public AddressModel ListAddressById(int id)
        {
            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                return address;
            }
            return null;
        }

        public void UpdateAddress(int id, AddressModel addressUpdate)
        {

            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address != null)
            {
                _context.SaveChanges();
            }

        }
        public void DeleteAddress(int id)
        {
            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address != null)
            {
                _context.Remove(address);
                _context.SaveChanges();
            }
        }
    }
}
