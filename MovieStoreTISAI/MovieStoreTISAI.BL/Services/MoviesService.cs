using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.BL.Services
{
    internal class MoviesService : IMoviesService
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }
    }
}
