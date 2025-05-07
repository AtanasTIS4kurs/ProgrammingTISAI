using MovieStoreB.DL.Cache;
using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    //public interface IMovieRepository
    //{
    //    Task<List<Movie>> GetAll();
    //    Task Add(Movie movie);
    //    Task<Movie?> GetByID(string id);
    //    Task Delete(string id);

    //    Task Update(Movie movie);
    //}
    public interface IMovieRepository : ICacheRepository<Movie>
    {
        Task<List<Movie>> GetMovies();

        void AddMovie(Movie movie);

        void DeleteMovie(string id);

        Movie? GetMoviesById(string id);

        Task<IEnumerable<Movie?>> GetMoviesAfterDateTime(DateTime date);
    }
}
