using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAll();
        Task Add(Movie movie);
        Task<Movie?> GetByID(string id);
        Task Delete(string id);

        Task Update(Movie movie);
    }
}
