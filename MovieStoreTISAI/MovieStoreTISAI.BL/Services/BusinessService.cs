using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.DTO;
using MovieStoreTISAI.Models.Responses;

namespace MovieStoreTISAI.BL.Services
{
    internal class BusinessService : IBusinessService
    {
        private readonly IMovieRepository _movieRepository;

        private readonly IActorRepository _actorRepository;
        public BusinessService(
            IMovieRepository movieRepository,
            IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
        }


        public async Task<List<MovieFullDetailsResponse>> GetAllMovies()
        {
            var result = new List<MovieFullDetailsResponse>();
            var movies = await _movieRepository.GetAll();
            var actors = await _actorRepository.GetAll();
            foreach (var movie in movies)
            {
                var detailedMovie = new MovieFullDetailsResponse()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    Actors = new List<Actor>()

                };
                var tasks = movie.Actors.Select(actorId => _actorRepository.GetByID(actorId)).ToList();
                //Друг начин
                //var tasks = new List<Task<Actor>>();
                //foreach (var actorId in movie.Actors)
                //{
                //    var t = _actorRepository.GetByID(actorId);
                //    tasks.Add(t);
                //}
                //var response = await Task.WhenAll(tasks);
                // if (response != null && response.Any()) movie.Actors = response.ToList();
                //detailedMovie.Actors = response.ToList();
                //var actors:List<Actor> await _actorRepository.GetActors(detailedMovie);
                var actor = await _actorRepository.GetActors(movie.Actors);
                detailedMovie.Actors = actor;
                result.Add(detailedMovie);
            }

            return result;
        }
    }
}
