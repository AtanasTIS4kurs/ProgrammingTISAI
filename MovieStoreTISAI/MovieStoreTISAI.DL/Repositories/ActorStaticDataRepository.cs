using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.DL.StaticData;
using MovieStoreTISAI.Models.DTO;


namespace MovieStoreTISAI.DL.Repositories
{
    internal class ActorStaticDataRepository : IActorRepository
    {
        //public void Add()
        //{

        //}
       
        public List<Actor> GetAll()
        {
            return StaticDb.Actors;
        }
        public Actor? GetByID(int id)
        {
            if (id <= 0) return null;

            return StaticDb.Actors
                .FirstOrDefault(x => x.Id == id);
        }
        public void Delete(int id)
        {
            var actor = GetByID(id);

            if (actor != null)
            {
                StaticDb.Actors.Remove(actor);
            }
        }

    }
}
