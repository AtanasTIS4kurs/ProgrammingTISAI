using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie? GetByID(int id);
        void Delete(int id);
    }
}
