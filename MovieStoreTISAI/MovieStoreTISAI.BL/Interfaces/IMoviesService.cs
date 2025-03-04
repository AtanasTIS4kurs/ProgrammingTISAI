using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.BL.Interfaces
{
    public interface IMoviesService
    {
        Task Update(Movie movie);
        Task<List<Movie>> GetAll();

        Task<Movie?> GetByID(string id);

        Task Delete(string id);

        Task Add(Movie movie);

        Task AddActorToMovie(string movieId, string actorId);
    }
}
