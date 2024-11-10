using ProgramingTISAI.Models.DTO;
namespace ProgramingTISAI.DL.Interfaces
{
    public interface IMovieRepository
    {
        public List<Movie> GetALL()
        {
            return StaticDb.Movies;
        }
    }
}
