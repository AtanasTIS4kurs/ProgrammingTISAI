using Moq;
using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.BL.Services;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.Test
{
    public class BusinessServiceUnitTest
    {
        private readonly Mock<IMoviesService> _movieServiceMock;

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
        public static List<Movie> _movies  = new List<Movie>()
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
        public BusinessServiceUnitTest()
        {
            _movieServiceMock = new Mock<IMoviesService>();
            _actorRepositoryMock = new Mock<IActorRepository>();

        }

        [Fact]
        public async void GetAllMoviesDetails_OK()
        {
            //setup
            var expectedCount = 2;

            _movieServiceMock
                .Setup(x => x.GetMovies())
                .ReturnsAsync(_movies);

            _actorRepositoryMock
                .Setup(repo =>
                    repo.GetById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _actors.FirstOrDefault(x => x.Id == id));

            //inject
            var bussinessSevice = new BusinessService(
                _movieServiceMock.Object,
                _actorRepositoryMock.Object
                );
            //act
            var result = await bussinessSevice.GetAllMovieDetails();

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }
    }
}