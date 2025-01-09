using Moq;
using MovieStoreTISAI.BL.Services;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.Test
{
    public class BusinessServiceUnitTest
    {
        private readonly Mock<IMovieRepository> _movieRepositoryMock;

        private readonly Mock<IActorRepository> _actorRepositoryMock;

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
        public static List<Movie> _movies  = new List<Movie>()
                {
                    new Movie()
                    {
                       // Id = 1,
                        Title = "Test",
                        Year = 2016,
                        Actors = ["c5261ebc-40f9-4ad2-a0cf-b5301a288496","fde7c59b-a5d8-4b5d-88e9-e75d85c2e2cc"],
                    },
                    new Movie()
                    {
                      //  Id = 2,
                        Title = "Test2",
                        Year = 2017,
                        Actors =[ "fde7c59b-a5d8-4b5d-88e9-e75d85c2e2cc", "1be86f99-3600-41a3-879a-5dc6d7760808" ],
                    },
                    new Movie()
                    {
                       // Id = 3,
                        Title = "Test3",
                        Year = 2018,
                        Actors =["c5261ebc-40f9-4ad2-a0cf-b5301a288496", "1be86f99-3600-41a3-879a-5dc6d7760808" ],
                    }
                };
        public BusinessServiceUnitTest()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
            _actorRepositoryMock = new Mock<IActorRepository>();

        }
        
        [Fact]
        public void GetAllMovies_OK()
        {
            //setup
            var expectedCount = 2;

            _movieRepositoryMock.Setup(x => x.GetAll()).Returns(_movies);
            //_actorRepositoryMock.Setup(x => x.GetById(It.IsAny<string>())).Returns((string id)=>_actors.FirstOrDefault(x=>x.Id == id));
            //_actorRepositoryMock.Setup(x => x.GetAll()).Returns(_actors);

            //inject
            var bussinessSevice = new BusinessService(
                _movieRepositoryMock.Object,
                _actorRepositoryMock.Object
                );
            //act
            var result=bussinessSevice.GetAllMovies();

            //assert
            Assert.NotNull( result );
            Assert.Equal( expectedCount, result.Count );
        }
    }
}