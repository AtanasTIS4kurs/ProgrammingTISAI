using ProgramingTISAI.DL.Interfaces;
using ProgramingTISAI.DL.StatsData;
using ProgramingTISAI.Models.DTO;
namespace ProgramingTISAI.DL.Repositories
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
