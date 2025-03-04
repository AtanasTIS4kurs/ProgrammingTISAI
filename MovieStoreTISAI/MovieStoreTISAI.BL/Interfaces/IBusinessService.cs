using MovieStoreTISAI.Models.Responses;

namespace MovieStoreTISAI.BL.Interfaces
{
    public interface IBusinessService
    {   
        List<MovieFullDetailsResponse> GetAllMovies();
    }
}
