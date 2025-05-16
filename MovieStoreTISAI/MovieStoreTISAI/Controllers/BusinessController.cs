using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.Models.DTO;
using MovieStoreTISAI.Models.Requests;
namespace MovieStoreTISAI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesBlController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        private readonly ILogger<MoviesController> _logger;

        public MoviesBlController(
            IMoviesService movieService,
            ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpPost("TestFluentValid")]
        public async Task<IActionResult> TestFluentValid([FromBody] TestRequest movieRequest) { 
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Movie>> GetAll()
        {
            try
            {
                return await _movieService.GetMovies();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in GetAll {e.Message}-{e.StackTrace}");
            }
            return await _movieService.GetMovies();
        }
    }

    public class TestRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}

