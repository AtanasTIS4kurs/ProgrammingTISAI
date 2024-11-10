using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
    }
}
