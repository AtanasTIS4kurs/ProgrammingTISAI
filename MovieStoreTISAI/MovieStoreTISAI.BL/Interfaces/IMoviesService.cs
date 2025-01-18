using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.BL.Interfaces
{
    public interface IMoviesService
    {
        
        List<Movie> GetAll();

        Movie? GetByID(string id);

        void Delete(string id);

        void Add(Movie movie);

        void AddActorToMovie(string movieId, string actorId);
    }
}
