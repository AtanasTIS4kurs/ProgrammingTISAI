using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.Models.DTO;
using MovieStoreTISAI.Models.Requests;
namespace MovieStoreTISAI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        private readonly IMapper _mapper;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(
            IMoviesService movieService,
            IMapper mapper,
            ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Movie>> GetAll()
        {
            try
            {
                await _movieService.GetMovies();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error in GetAll {e.Message}-{e.StackTrace}");
            }
            return await _movieService.GetMovies();
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

            var result =
                _movieService.GetMoviesById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("AddMovie")]
        public void AddMovie(
            [FromBody] AddMovieRequest movieRequest)
        {
            var movie = _mapper.Map<Movie>(movieRequest);

            _movieService.AddMovie(movie);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest($"Wrong id:{id}");

            _movieService.DeleteMovie(id);

            return Ok();
        }
    }
}

