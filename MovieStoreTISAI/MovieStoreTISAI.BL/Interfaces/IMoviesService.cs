using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.BL.Interfaces
{
    public interface IMoviesService
    {
        Task<List<Movie>> GetMovies();

        void AddMovie(Movie movie);

        void DeleteMovie(string id);

        Movie? GetMoviesById(string id);

        void AddActor(string movieId, Actor actor);
    }
}
