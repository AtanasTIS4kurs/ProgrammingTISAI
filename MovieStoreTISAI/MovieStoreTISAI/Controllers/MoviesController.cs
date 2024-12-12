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

        public IActionResult GetAll()
        {
            var result = _movieService.GetAll();

            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }

            return NotFound();
        }
        
        
        //[ProducesResponseType(200)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Add")]
        public IActionResult Add([FromBody] AddMovieRequest movie)
        {
            var movieDto = _mapper.Map<Movie>(movie);

            _movieService.Add(movieDto);

            return Ok();
        }
        [HttpGet("GetByID")]
        public Movie? GetByID(string id)
        {
            //if (id > 0)
            //{
            //    return BadRequest($wrong Id)
            //}
            return _movieService.GetByID(id);

        }
        [HttpGet("Delete")]
        public void Delete(string id)
        {
             _movieService.Delete(id);

        }
    }
}

