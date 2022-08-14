using Microsoft.AspNetCore.Mvc;
using MoviesApi.Domain.Dtos.Request.Manager;
using MoviesApi.Services;
using System.Collections.Generic;
using FluentResults;
using MoviesApi.Domain.Dtos.Response;

namespace MoviesApi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private ManagerService _managerService;

        public ManagerController(ManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost]
        public IActionResult AddManager([FromBody] ManagerDTO managerDTO)
        {
            ManagerViews managerViews = _managerService.AddManager(managerDTO);

            return CreatedAtAction(nameof(ListManagerById), new { Id = managerViews.Id }, managerViews);
        }

        [HttpGet]
        public IActionResult ListManager()
        {
            IEnumerable<ManagerViews> managerViews = _managerService.ListManager();

            if (managerViews != null)
                return Ok(managerViews);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult ListManagerById(int id)
        {
            ManagerViews managerViews = _managerService.ListManagerById(id);

            if (managerViews != null)
                return Ok(managerViews);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteManager(int id)
        {
            Result result = _managerService.DeleteManager(id);

            if (result.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
