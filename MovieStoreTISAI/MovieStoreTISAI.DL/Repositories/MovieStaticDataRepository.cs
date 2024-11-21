using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.DL.StaticData;
using MovieStoreTISAI.Models.DTO;


namespace MovieStoreTISAI.DL.Repositories
{
    internal class MovieStaticDataRepository : IMovieRepository
    {
        //public void Add()
        //{

        //}
        public List<Movie> GetAll()
        {
            return StaticDb.Movies;
        }
        public Movie? GetByID(int id)
        {
            if (id <= 0) return null;

            return StaticDb.Movies
                .FirstOrDefault(x => x.Id == id);
        }
        public void Delete(int id)
        {
            var movie = GetByID(id);

            if (movie != null)
            {
                StaticDb.Movies.Remove(movie);
            }
        }

    }
}
