	using F1Schedule.Data;
using F1Schedule.Models.Directors;
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
        List<Director> vars = new List<Director>
            {
                new Director() { Id = 1, Name = "Seb Seb"},
                new Director() { Id = 2, Name = "Ham Ham"},
            };
        Director var = new Director() { Id = 3, Name = "Ham Ham" };
        [Fact]
        public async Task GetEntityListTest()
        {
            var fakeRepositoryMock = new Mock<IDirectorsContext>();
            fakeRepositoryMock.Setup(x => x.GetDirectorsList()).ReturnsAsync(vars);


            var directorService = new DirectorsService(fakeRepositoryMock.Object);


            var result = await directorService.GetActorsList();

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
            var fakeRepositoryMock = new Mock<IDirectorsContext>();
            fakeRepositoryMock.Setup(x => x.GetDirectorsSingle(It.IsAny<int>())).ReturnsAsync(var);


            var directorService = new DirectorsService(fakeRepositoryMock.Object);

            var result = await actorService.GetDirectorsSingle(3);

            Assert.Equal("Ham Ham", result.Name);
        }

        [Fact]
        public async Task AddAndSaveEntityTest()
        {
            var fakeRepository = Mock.Of<IDirectorsContext>();
            var directorService = new DirectorsService(fakeRepository);
            await directorService.AddAndSaveDirector(var);
        }


        [Fact]
        public async Task SetEntityTest()
        {
            var fakeRepository = Mock.Of<IDirectorsContext>();
            var directorService = new DirectorsService(fakeRepository);
            await directorService.SetDirector(var);
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IDirectorsContext>();
            fakeRepositoryMock.Setup(x => x.GetDirectorsList()).ReturnsAsync(vars);


            var directorService = new DirectorsService(fakeRepositoryMock.Object);
            
            await directorService.DeleteDirector(2);
        }
    }
}