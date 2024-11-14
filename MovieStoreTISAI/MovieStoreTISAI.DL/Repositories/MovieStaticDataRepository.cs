using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.DL.StaticData;
using MovieStoreTISAI.Models.DTO;


namespace MovieStoreTISAI.DL.Repositories
{
    internal class MovieStaticDataRepository : IMovieRepository
    {
        public List<Movie> GetAll()
        {
            return StaticDb.Movies;
        }
    }

    internal class MovieMongoRepository : IMovieRepository
    {
        public List<Movie> GetAll()
        {
            return StaticDb.Movies;
        }
    }
}
