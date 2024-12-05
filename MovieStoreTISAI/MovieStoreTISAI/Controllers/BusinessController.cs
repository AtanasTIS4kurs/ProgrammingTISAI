using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.Models.DTO;
using MovieStoreTISAI.Models.Requests;
namespace MovieStoreTISAI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {

        private readonly IBusinessService _blService;
        public BusinessController(IBusinessService movieService)
        {
            _blService = movieService;
        }
        [HttpGet("GetALLDetiledMovies")]
        public IActionResult GetAllDetailedMovie()
        {
            var result = _blService.GetAllMovies();
            if (result != null && result.Count < 0)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}

