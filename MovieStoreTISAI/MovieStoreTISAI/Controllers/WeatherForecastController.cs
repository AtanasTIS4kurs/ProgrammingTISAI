using Microsoft.AspNetCore.Mvc;
using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {

        private readonly IMoviesService _movieService;

        public MoviesController(IMoviesService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetALL")]
        public IEnumerable<Movie> Get()
        {
            return _movieService.GetAll();

        }
    }
}

