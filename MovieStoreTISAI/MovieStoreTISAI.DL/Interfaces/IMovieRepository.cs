using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        void Add(Movie movie);
        Movie? GetByID(string id);
        void Delete(string id);
    }
}
