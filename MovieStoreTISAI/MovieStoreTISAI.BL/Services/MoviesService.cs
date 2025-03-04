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


        public async Task Add(Movie movie)
        {
           
             await _movieRepository.Add(movie);
        }
        public async Task Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return;
           await _movieRepository.Delete(id);
        }

        public async Task<Movie?> GetByID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogError("MovieId is null or empty");
                return null;
            }
            return  await _movieRepository.GetByID(id);
        }

        public async Task<List<Movie>> GetAll()
        {
            return await _movieRepository.GetAll();
        }

        public async Task AddActorToMovie(string movieId, string actorId)
        {
            if (string.IsNullOrEmpty(movieId) || string.IsNullOrEmpty(actorId))
            {
                _logger.LogError("MovieId or ActorId is null or empty");
                return;
            }

            if (!Guid.TryParse(movieId, out _) || !Guid.TryParse(actorId, out _))
            {
                _logger.LogError("MovieId or ActorId is not a valid Guid");
                return;
            }

            var movie = await _movieRepository.GetByID(movieId);

            if (movie == null)
            {
                _logger.LogError("Movie not found");
                return;
            }

            var actor = await _actorRepository.GetByID(actorId);
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

           await _movieRepository.Update(movie);
        }

        public async Task Update(Movie movie)
        {
            await _movieRepository.Update(movie);
        }
    }
}
