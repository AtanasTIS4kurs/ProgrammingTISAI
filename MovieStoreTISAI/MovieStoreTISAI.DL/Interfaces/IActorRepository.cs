using MovieStoreTISAI.Models.DTO;
namespace MovieStoreTISAI.DL.Interfaces
{
    public interface IActorRepository
    {
        List<Actor> GetAll();
        Actor? GetByID(int id);
        void Delete(int id);
    }
}
