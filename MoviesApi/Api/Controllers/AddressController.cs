using Microsoft.AspNetCore.Mvc;
using MoviesApi.Domain.Dtos.Request.Address;
using MoviesApi.Services;
using System.Collections.Generic;
using FluentResults;
using MoviesApi.Domain.Dtos.Response;

namespace MoviesApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] AddressDTO addressDTO)
        {
            AddressViews addressViews = _addressService.AddAddress(addressDTO);

            return CreatedAtAction(nameof(ListAddressById), new { Id = addressViews.Id }, addressViews);
        }

        [HttpGet]
        public IActionResult ListAddress()
        {
            IEnumerable<AddressViews> addressViews = _addressService.ListAddress();

            if (addressViews != null)
                return Ok(addressViews);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult ListAddressById(int id)
        {
            AddressViews addressViews = _addressService.ListAddressById(id);

            if (addressViews != null)
                return Ok(addressViews);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDTO addressDTO)
        {
            Result result = _addressService.UpdateAddress(id, addressDTO);

            if (result.IsFailed)
                return NotFound();

            return NoContent();

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            Result result = _addressService.DeleteAddress(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();

        }
    }
}
