using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Database;
using MoviesApi.Dtos.Manager;
using MoviesApi.Models;
using MoviesApi.Views;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly MoviesApiContext _context;
        private readonly IMapper _mapper;

        public ManagerController(MoviesApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddManager([FromBody] ManagerDTO managerDTO)
        {

            ManagerModel manager = _mapper.Map<ManagerModel>(managerDTO);

            _context.Manager.Add(manager);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListManagerById), new { Id = manager.Id }, manager);
        }

        [HttpGet]
        public IEnumerable<ManagerViews> ListManager()
        {
            IEnumerable<ManagerModel> manager = _context.Manager.ToList();

            if (manager != null)
            {

                IEnumerable<ManagerViews> managerViews = _mapper.Map<IEnumerable<ManagerViews>>(manager);
                return managerViews;
            }

            return null;
        }

        [HttpGet("{id}")]
        public IActionResult ListManagerById(int id)
        {

            ManagerModel manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);
            if (manager != null)
            {

                ManagerViews managerViews = _mapper.Map<ManagerViews>(manager);
                return Ok(managerViews);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteManager(int id)
        {

            ManagerModel manager = _context.Manager.FirstOrDefault(manager => manager.Id == id);

            if (manager == null)
            {
                return NotFound();
            }

            _context.Remove(manager);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
