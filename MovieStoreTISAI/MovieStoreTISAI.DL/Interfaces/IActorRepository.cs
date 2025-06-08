using MovieStoreTISAI.DL.Cache;
using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IActorRepository : ICacheRepository<string, Actor>
    {
        Task<Actor?> GetById(string id);

        Task<IEnumerable<Actor?>> GetAllActors();
    }
}
