using Mapster;
using MovieStoreTISAI.Models.DTO;
using MovieStoreTISAI.Models.Requests;

namespace MovieStoreTISAI.MapConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddMovieRequest, Movie>
                    .NewConfig();
                    //.TwoWays()
        }
    }
}
