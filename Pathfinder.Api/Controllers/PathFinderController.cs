using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pathfinder.Interfaces;

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
