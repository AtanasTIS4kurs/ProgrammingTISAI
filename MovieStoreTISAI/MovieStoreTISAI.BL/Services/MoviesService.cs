using Microsoft.Extensions.Logging;
using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.BL.Services
{
    internal class MoviesService : IMoviesService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly ILogger<MoviesService> _logger;

        public MoviesService(
            IMovieRepository movieRepository,
            ILogger<MoviesService> logger,
            IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _logger = logger;
            _actorRepository = actorRepository;
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
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogError("MovieId is null or empty");
                return null;
            }
            return _movieRepository.GetByID(id);
        }

        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public void AddActorToMovie(string movieId, string actorId)
        {
            if (string.IsNullOrEmpty(movieId) || string.IsNullOrEmpty(actorId))
            {
                _logger.LogError("MovieId or ActorId is null or empty");
                return;
            }

            if(!Guid.TryParse(movieId, out _) || !Guid.TryParse(actorId, out _))
            {
                _logger.LogError("MovieId or ActorId is not a valid Guid");
                return;
            }

            var movie = _movieRepository.GetByID(movieId);

            if (movie == null)
            {
                _logger.LogError("Movie not found");
                return;
            }

            var actor = _actorRepository.GetByID(actorId);
            if (actor == null) 
            { 
                _logger.LogError("Actor not found");
                return;
            }
            if (movie.Actors == null)
            {
                movie.Actors = new List<string>();
            }
            movie.Actors.Add(actorId); 

            _movieRepository.Update(movie);
        }
    }
}
