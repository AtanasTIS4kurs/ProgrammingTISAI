using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.Responses;

namespace MovieStoreTISAI.BL.Services
{
    internal class BusinessService : IBusinessService
    {
        private readonly IBusinessService _movieService;
        private readonly IActorRepository _actorRepository;

        public BusinessService(IMoviesService movieService, IActorRepository actorRepository)
        {
            _movieService = movieService;
            _actorRepository = actorRepository;
        }

        public async Task<List<FullMovieDetails>> GetAllMovieDetails()
        {
            var result = new List<FullMovieDetails>();

            var movies = await _movieService.GetMovies();

            foreach (var movie in movies)
            {
                var movieDetails = new FullMovieDetails();
                movieDetails.Title = movie.Title;
                movieDetails.Year = movie.Year;
                movieDetails.Id = movie.Id;

                foreach (var actorId in movie.ActorIds)
                {
                    var actor = _actorRepository.GetById(actorId);
                }

                result.Add(movieDetails);
            }
            return result;
        }
    }
}