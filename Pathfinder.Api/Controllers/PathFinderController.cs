using Microsoft.AspNetCore.Mvc;
using Pathfinder.Interfaces;
using System;

namespace Pathfinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathFinderController : Controller
    {
        private readonly IPathFinderService pathFinderService;

        public PathFinderController(IPathFinderService pathFinderService)
        {
            this.pathFinderService = pathFinderService;
        }

        [HttpPost("[action]")]
        public IActionResult FindPath([FromBody] int[] request)
        {
            try
            {
                return Ok(pathFinderService.FindPath(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok("I am path finder service");
        }
    }
}
