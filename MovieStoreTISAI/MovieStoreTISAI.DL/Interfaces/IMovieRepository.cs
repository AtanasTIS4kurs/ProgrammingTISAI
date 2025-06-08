using MovieStoreTISAI.DL.Cache;
using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IMovieRepository : ICacheRepository<string, Movie>
    {
        Task<List<Movie>> GetMovies();

        Task AddMovie(Movie movie);

        Task DeleteMovie(string id);

        //Task<Movie?> GetMoviesById(string id);

        Movie? GetMoviesById(string id);
    }
}
