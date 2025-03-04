//using MovieStoreTISAI.DL.Interfaces;
//using MovieStoreTISAI.DL.StaticData;
//using MovieStoreTISAI.Models.DTO;


//namespace MovieStoreTISAI.DL.Repositories
//{
//    internal class ActorStaticDataRepository : IActorRepository
//    {
//        public void Add()
//        {
//        }

//        public List<Actor> GetAll()
//        {
//            return StaticDb.Actors;
//        }
//        public Actor? GetByID(string id)
//        {
//            if (!string.IsNullOrEmpty(id)) return null;
//            else
//            return StaticDb.Actors.FirstOrDefault(a => a.Id == id);
//        }
//        public void Delete(string id)
//        {
//            var actor = GetByID(id);

//            if (!string.IsNullOrEmpty(id) && actor != null)
//            {
//                StaticDb.Actors.Remove(actor);
//            }
//        }

//    }
//}
