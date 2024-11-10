using ProgramingTISAI.BL.Interfaces;
using ProgramingTISAI.DL.Interfaces;
using ProgramingTISAI.Models.DTO;


namespace ProgramingTISAI.BL.Services
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
