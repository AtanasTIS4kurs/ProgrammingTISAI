using MovieStoreTISAI.Models.Responses;

namespace MovieStoreTISAI.BL.Interfaces
{
    public interface IBlMovieService
    {
        Task<List<FullMovieDetails>> GetAllMovieDetails();
    }
}
