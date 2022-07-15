using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Database;
using MoviesApi.Dtos.Address;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public AddressController(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] AddressDTO addressDTO)
        {

            AddressModel address = _mapper.Map<AddressModel>(addressDTO);

            _context.Address.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListAddressById), new { Id = address.Id }, address);
        }

        [HttpGet]
        public IEnumerable<AddressViews> ListAddress()
        {
            IEnumerable<AddressModel> address = _context.Address.ToList();

            if (address != null)
            {

                IEnumerable<AddressViews> addressViews = _mapper.Map<IEnumerable<AddressViews>>(address);
                return addressViews;
            }

            return null;
        }

        [HttpGet("{id}")]
        public IActionResult ListAddressById(int id)
        {

            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {

                AddressViews addressViews = _mapper.Map<AddressViews>(address);
                return Ok(addressViews);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDTO addressDTO)
        {

            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null)
            {
                return NotFound();
            }

            _mapper.Map(addressDTO, address);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {

            AddressModel address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null)
            {
                return NotFound();
            }

            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
