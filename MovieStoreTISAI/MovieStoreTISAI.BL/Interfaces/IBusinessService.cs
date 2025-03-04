using MovieStoreTISAI.Models.Responses;

namespace MovieStoreTISAI.BL.Interfaces
{
    public interface IBusinessService
    {   
        Task<List<MovieFullDetailsResponse>> GetAllMovies();
    }
}
