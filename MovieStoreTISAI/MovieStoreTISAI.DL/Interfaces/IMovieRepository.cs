using MovieStoreB.DL.Cache;
using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IMovieRepository : ICacheRepository<string, Movie>
    {
        Task<List<Movie>> GetMovies();

        void AddMovie(Movie movie);

        void DeleteMovie(string id);

        Movie? GetMoviesById(string id);
    }
}
