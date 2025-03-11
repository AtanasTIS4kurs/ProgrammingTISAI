using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAll();
        Task Add(Actor actor);
        Task<Actor?> GetByID(string id);
        Task Delete(string id);
        Task<List<Actor>> GetActors(List<string> id);
        Task Update(Actor actor);
    }
}
