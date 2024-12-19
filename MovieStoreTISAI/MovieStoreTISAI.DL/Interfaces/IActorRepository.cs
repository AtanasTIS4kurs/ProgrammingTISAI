using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IActorRepository
    {
        List<Actor> GetAll();
        Actor? GetByID(string id);
        void Delete(string id);
    }
}
