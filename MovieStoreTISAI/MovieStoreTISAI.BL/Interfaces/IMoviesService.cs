using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.BL.Interfaces
{
    public interface IMoviesService
    {
        
        List<Movie> GetAll();

        Movie? GetByID(int id);

        void Delete(int id);
    }
}
