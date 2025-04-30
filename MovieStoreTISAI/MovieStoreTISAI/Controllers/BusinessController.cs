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
        //fix this
        [HttpGet("GetALLDetailedMovies")]
        public IActionResult GetAllDetailedMovie()
        {
            var result = _blService.GetAllMovies();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("GetMovieById/{id}")]
        public IActionResult GetMovieById(string id)
        {
            var result = _blService.GetMovieById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}

