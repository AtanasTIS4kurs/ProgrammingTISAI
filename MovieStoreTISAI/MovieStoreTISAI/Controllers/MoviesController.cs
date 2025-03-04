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
        public MoviesController(IMoviesService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }
        [HttpGet("GetALL")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _movieService.GetAll();

            return result != null && result.Count > 0 ? Ok(result) : NotFound();
        }
        [HttpPost("Add")]
        public async Task<IActionResult>  Add([FromBody] AddMovieRequest movie)
        {
            var movieDto = _mapper.Map<Movie>(movie);
              if (movieDto == null) return BadRequest();
            await _movieService.Add(movieDto);
            return Ok(movieDto);
        }
        [HttpGet("GetByID")]
        public async Task<Movie?> GetByID(string id)
        {
            
            return await _movieService.GetByID(id);

        }
        [HttpGet("Delete")]
        public async Task Delete(string id)
        {
            await _movieService.Delete(id);

        }
    }
}

