using F1Schedule.Data;
using F1Schedule.Models.Movies;
using F1Schedule.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Test
{
    public class DriversServiceTest
    {
        List<Movie> vars = new List<Movie>
            {
                new Movie() { Id = 1, Name = "Seb Seb"},
                new Movie() { Id = 2, Name = "Ham Ham"},
            };
        Movie var = new Movie() { Id = 3, Name = "Ham Ham" };
        [Fact]
        public async Task GetEntityListTest()
        {
            var fakeRepositoryMock = new Mock<IMoviesContext>();
            fakeRepositoryMock.Setup(x => x.GetMoviesList()).ReturnsAsync(vars);


            var movieService = new MoviesService(fakeRepositoryMock.Object);


            var result = await movieService.GetMoviesList();

            Assert.Collection(result, var =>
            {
                Assert.Equal("Seb Seb", var.Name);
            },
            car =>
            {
                Assert.Equal("Ham Ham", var.Name);
            });
        }

        [Fact]
        public async Task GetSingleEntityTest()
        {
            var fakeRepositoryMock = new Mock<IMoviesContext>();
            fakeRepositoryMock.Setup(x => x.GetMoviesSingle(It.IsAny<int>())).ReturnsAsync(var);


            var movieService = new MoviesService(fakeRepositoryMock.Object);

            var result = await movieService.GetMoviesSingle(3);

            Assert.Equal("Ham Ham", result.Name);
        }

        [Fact]
        public async Task AddAndSaveEntityTest()
        {
            var fakeRepository = Mock.Of<IMoviesContext>();
            var movieService = new MoviesService(fakeRepository);
            await userService.AddAndSaveMovie(var);
        }


        [Fact]
        public async Task SetEntityTest()
        {
            var fakeRepository = Mock.Of<IMoviesContext>();
            var movieService = new MoviesService(fakeRepository);
            await movieService.SetMovie(var);
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IMoviesContext>();
            fakeRepositoryMock.Setup(x => x.GetMoviesList()).ReturnsAsync(vars);


            var movieService = new MoviesService(fakeRepositoryMock.Object);
            
            await movieService.DeleteMovie(2);
        }
    }
}