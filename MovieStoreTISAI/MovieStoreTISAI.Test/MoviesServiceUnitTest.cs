using Moq;
using Microsoft.Extensions.Logging;
using MovieStoreTISAI.BL.Services;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.Test
{
    public class MoviesServiceUnitTest
    {
        private readonly Mock<IMovieRepository> _movieRepositoryMock;

        private readonly Mock<IActorRepository> _actorRepositoryMock;
        private readonly Mock<ILogger<MoviesService>> _loggerMock;

        public static List<Actor> _actors = new List<Actor>()
                {
                    new Actor()
                    {
                       // Id = 1,
                       Id = "c5261ebc-40f9-4ad2-a0cf-b5301a288496",
                        Name = "Actor1"
                    },
                    new Actor()
                    {
                       // Id = 2,
                       Id = "fde7c59b-a5d8-4b5d-88e9-e75d85c2e2cc",
                        Name = "Actor2"
                    },
                    new Actor()
                    {
                       // Id = 3,
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
                        Actors = ["c5261ebc-40f9-4ad2-a0cf-b5301a288496","fde7c59b-a5d8-4b5d-88e9-e75d85c2e2cc"],
                    },
                    new Movie()
                    {
                      Id = Guid.NewGuid().ToString(),
                        Title = "Test2",
                        Year = 2017,
                        Actors =[ "fde7c59b-a5d8-4b5d-88e9-e75d85c2e2cc", "1be86f99-3600-41a3-879a-5dc6d7760808" ],
                    },
                    new Movie()
                    {
                       Id = Guid.NewGuid().ToString(),
                        Title = "Test3",
                        Year = 2018,
                        Actors =["c5261ebc-40f9-4ad2-a0cf-b5301a288496", "1be86f99-3600-41a3-879a-5dc6d7760808" ],
                    }
                };
        public MoviesServiceUnitTest()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _actorRepositoryMock = new Mock<IActorRepository>();

        }

        [Fact]
        void GetByID_OK()
        {
            // Arrange
            var movieId = _movies[0].Id;
            _movieRepositoryMock.Setup(x => x.GetByID(It.IsAny<string>()))
                .Returns((string id) => _movies.FirstOrDefault(m => m.Id == id));
            var loggerMock = new Mock<ILogger<MoviesService>>();
            ILogger<MoviesService> logger = loggerMock.Object;
            // Act
            var movieService = new MoviesService(_movieRepositoryMock.Object, logger, _actorRepositoryMock.Object);

            var result = movieService.GetByID(movieId);

            // Assert
            Assert.NotNull(result);
           // Assert.Equal(movieId, result.Id);
        }
        [Fact]
        void GetByID_NoId()
        {
            // Arrange
            var movieId = Guid.NewGuid().ToString();
            _movieRepositoryMock.Setup(x => x.GetByID(It.IsAny<string>()))
                .Returns((string id) => _movies.FirstOrDefault(m => m.Id == id));

            var loggerMock = new Mock<ILogger<MoviesService>>();
            ILogger<MoviesService> logger = loggerMock.Object;

            // Act
            var movieService = new MoviesService(_movieRepositoryMock.Object, logger, _actorRepositoryMock.Object);

            var result = movieService.GetByID(movieId);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        void GetByID_WrongId()
        {
            // Arrange
            var movieId = "dW23FG";
            _movieRepositoryMock.Setup(x => x.GetByID(It.IsAny<string>()))
                .Returns((string id) => _movies.FirstOrDefault(m => m.Id == id));
            var loggerMock = new Mock<ILogger<MoviesService>>();
            ILogger<MoviesService> logger = loggerMock.Object;
            // Act
            var movieService = new MoviesService(_movieRepositoryMock.Object, logger, _actorRepositoryMock.Object);

            var result = movieService.GetByID(movieId);

            // Assert
            Assert.Null(result);
        }
        //[Fact]
        //void AddActorToMovie_OK()
        //{
        //    // Arrange
        //    var movie = _movies[0];
        //    var actor = _actors[0];
        //    _movieRepositoryMock.Setup(x => x.GetByID(It.IsAny<string>()))
        //         .Returns((string id) => _movies.FirstOrDefault(m => m.Id == id));
        //    _actorRepositoryMock.Setup(x => x.GetByID(It.IsAny<string>()))
        //        .Returns((string id) => _actors.FirstOrDefault(m => m.Id == id));

        //    var loggerMock = new Mock<ILogger<MoviesService>>();
        //    ILogger<MoviesService> logger = loggerMock.Object;

        //    // Act

        //    var Movieservice = new MoviesService(_movieRepositoryMock.Object, logger, _actorRepositoryMock.Object );
        //    Movieservice.AddActorToMovie(movie.Id, actor.Id);

        //    // Assert
        //    _movieRepositoryMock.Verify(x => x.GetByID(movie.Id), Times.Once);
        //    _actorRepositoryMock.Verify(x => x.GetByID(actor.Id), Times.Once);
        //    _movieRepositoryMock.Verify(x => x.Update(movie), Times.Once);
        //}
        //[Fact]
        //void AddActorToMovie_NullOK()
        //{
        //    // Arrange
        //    var movie = _movies[0];
        //    var actor = Guid.NewGuid().ToString(); 
        //    _movieRepositoryMock.Setup(x => x.GetByID(It.IsAny<string>()))
        //         .Returns((string id) => _movies.FirstOrDefault(m => m.Id == id));
        //    _actorRepositoryMock.Setup(x => x.GetByID(It.IsAny<string>()))
        //        .Returns((string id) => _actors.FirstOrDefault(m => m.Id == id));

        //    var loggerMock = new Mock<ILogger<MoviesService>>();
        //    ILogger<MoviesService> logger = loggerMock.Object;

        //    // Act

        //    var Movieservice = new MoviesService(_movieRepositoryMock.Object, logger, _actorRepositoryMock.Object);
        //    Movieservice.AddActorToMovie(movie.Id, actor);

        //    // Assert
        //    _movieRepositoryMock.Verify(x => x.GetByID(movie.Id), Times.Once);
        //    _actorRepositoryMock.Verify(x => x.GetByID(actor), Times.Once);
        //    _movieRepositoryMock.Verify(x => x.Update(movie), Times.Never);
        //}
        //[Fact]
        //void AddActorToMovie_WronglOK()
        //{
        //    // Arrange
        //    var movie = _movies[0];
        //    var actor = "asfqwe22";
        //    _movieRepositoryMock.Setup(x => x.GetByID(It.IsAny<string>()))
        //         .Returns((string id) => _movies.FirstOrDefault(m => m.Id == id));
        //    _actorRepositoryMock.Setup(x => x.GetByID(It.IsAny<string>()))
        //        .Returns((string id) => _actors.FirstOrDefault(m => m.Id == id));

        //    var loggerMock = new Mock<ILogger<MoviesService>>();
        //    ILogger<MoviesService> logger = loggerMock.Object;

        //    // Act

        //    var Movieservice = new MoviesService(_movieRepositoryMock.Object, logger, _actorRepositoryMock.Object);
        //    Movieservice.AddActorToMovie(movie.Id, actor);

        //    // Assert
        //    _movieRepositoryMock.Verify(x => x.GetByID(movie.Id), Times.Never);
        //    _actorRepositoryMock.Verify(x => x.GetByID(actor), Times.Never);
        //    _movieRepositoryMock.Verify(x => x.Update(movie), Times.Never);
        //}
    }
}
