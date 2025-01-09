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


        public void Add(Movie movie)
        {
            if (movie == null|| movie.Actors == null) return;
            foreach (var actor in movie.Actors)
            {
                //if (Guid.TryParse(actor.Id, out _)) return;
            }
            //  _movieRepository.Add(movie);
        }
        public void Delete(string id)
        {
            _movieRepository.Delete(id);
        }

        public Movie? GetByID(string id)
        {
            return _movieRepository.GetByID(id);
        }

        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

    }
}
