using Moq;
using MovieStoreTISAI.BL.Services;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.Test
{
    public class MoviesServiceUnitTest
    {
        private readonly Mock<IMovieRepository> _movieRepositoryMock;

        private readonly Mock<IActorRepository> _actorRepositoryMock;

        public static List<Actor> _actors = new List<Actor>()
                {
                    new Actor()
                    {
                       Id = "c5261ebc-40f9-4ad2-a0cf-b5301a288496",
                        Name = "Actor1"
                    },
                    new Actor()
                    {
                       Id = "fde7c59b-a5d8-4b5d-88e9-e75d85c2e2cc",
                        Name = "Actor2"
                    },
                    new Actor()
                    {
                       Id = "1be86f99-3600-41a3-879a-5dc6d7760808",
                        Name = "Actor3"
                    }
                };
        public static List<Movie> _movies = new List<Movie>()
                {
                    new Movie()
                    {
                       Id = Guid.NewGuid().ToString(),
                        Title = "Test",
                        Year = 2016,
                        ActorIds = ["c5261ebc-40f9-4ad2-a0cf-b5301a288496","fde7c59b-a5d8-4b5d-88e9-e75d85c2e2cc"],
                    },
                    new Movie()
                    {
                      Id = Guid.NewGuid().ToString(),
                        Title = "Test2",
                        Year = 2017,
                        ActorIds =[ "fde7c59b-a5d8-4b5d-88e9-e75d85c2e2cc", "1be86f99-3600-41a3-879a-5dc6d7760808" ],
                    },
                    new Movie()
                    {
                       Id = Guid.NewGuid().ToString(),
                        Title = "Test3",
                        Year = 2018,
                        ActorIds =["c5261ebc-40f9-4ad2-a0cf-b5301a288496", "1be86f99-3600-41a3-879a-5dc6d7760808" ],
                    }
                };
        public MoviesServiceUnitTest()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _actorRepositoryMock = new Mock<IActorRepository>();

        }

        [Fact]
        void GetMoviesById_OK()
        {
            // Arrange
            var movieId = _movies[0].Id;
            _movieRepositoryMock.Setup(x => x.GetMoviesById(It.IsAny<string>()))
                .Returns((string id) => _movies.FirstOrDefault(m => m.Id == id));
            // Act
            var movieService = new MoviesService(_movieRepositoryMock.Object,  _actorRepositoryMock.Object);

            var result = movieService.GetMoviesById(movieId);

            // Assert
            Assert.NotNull(result);
           // Assert.Equal(movieId, result.Id);
        }
        [Fact]
        void GetMoviesById_NoId()
        {
            // Arrange
            var movieId = Guid.NewGuid().ToString();
            _movieRepositoryMock.Setup(x => x.GetMoviesById(It.IsAny<string>()))
                .Returns((string id) => _movies.FirstOrDefault(m => m.Id == id));
            // Act
            var movieService = new MoviesService(_movieRepositoryMock.Object, _actorRepositoryMock.Object);

            var result = movieService.GetMoviesById(movieId);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        void GetMoviesById_WrongId()
        {
            // Arrange
            var movieId = "dW23FG";
            _movieRepositoryMock.Setup(x => x.GetMoviesById(It.IsAny<string>()))
                .Returns((string id) => _movies.FirstOrDefault(m => m.Id == id));
            // Act
            var movieService = new MoviesService(_movieRepositoryMock.Object,  _actorRepositoryMock.Object);

            var result = movieService.GetMoviesById(movieId);

            // Assert
            Assert.Null(result);
        }
    }
}
