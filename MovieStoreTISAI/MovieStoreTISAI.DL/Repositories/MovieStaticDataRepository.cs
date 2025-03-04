//using MovieStoreTISAI.DL.Interfaces;
//using MovieStoreTISAI.DL.StaticData;
//using MovieStoreTISAI.Models.DTO;


//namespace MovieStoreTISAI.DL.Repositories
//{
//    internal class MovieStaticDataRepository : IMovieRepository
//    {
//        public void Add()
//        {
//            //new Movie()
//            //{
//            //    Id = 4,
//            //    Title = "Test",
//            //    Year = 2020,
//            //    Actors = new List<int>() { 2 },
//            //};
//        }
//        public List<Movie> GetAll()
//        {
//            return StaticDb.Movies;
//        }
        
//        public Movie? GetByID(string id)
//        {
//            if (string.IsNullOrEmpty(id)) return null;

//            return StaticDb.Movies
//                .FirstOrDefault(x => x.Id == id);
//        }
//        public void Delete(string id)
//        {
//            var movie = GetByID(id);

//            if (movie != null)
//            {
//                StaticDb.Movies.Remove(movie);
//            }
//        }

//    }
//}
