using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MovieStoreTISAI.Models.DTO;
using MovieStoreTISAI.DL.Interfaces;

namespace MovieStoreTISAI.DL.Cache
{
    public class MongoCacheDistributor : BackgroundService
    {
        //Full load method - read entire collection and load it into memory - GetALlMOvies()
        //Diffload method - read only the changed data and load it into memory - GetUpdatedMovies(DateTime lastUsed)

        private readonly IMovieRepository<Movie> _movieRepository;
        public MongoCacheDistributor(IMovieRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var lastExecutionTime = DateTime.UtcNow;
            var result = _movieRepository.GetAll();

            foreach (var movie in result)
            {
                Console.WriteLine(movie.Title);
            }
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);

                var updatedMovies = await _movieRepository.GetUpdatedMovies(lastExecutionTime);

                lastExecutionTime = DateTime.UtcNow;

                foreach (var movie in updatedMovies)
                {
                    if (movie == null)
                    {
                        Console.WriteLine(movie.Title);
                    }
                }
            }
        }
    }
}
