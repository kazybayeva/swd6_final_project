using F1Schedule.Data;
using F1Schedule.Models.Actors;
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
        List<Actor> vars = new List<Actor>
            {
                new Actor() { Id = 1, Name = "Seb Seb"},
                new Actor() { Id = 2, Name = "Ham Ham"},
            };
        Actor var = new Actor() { Id = 3, Name = "Ham Ham" };
        [Fact]
        public async Task GetEntityListTest()
        {
            var fakeRepositoryMock = new Mock<IActorsContext>();
            fakeRepositoryMock.Setup(x => x.GetActorsList()).ReturnsAsync(vars);


            var actorService = new ActorsService(fakeRepositoryMock.Object);


            var result = await actorService.GetActorsList();

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
            var fakeRepositoryMock = new Mock<IActorsContext>();
            fakeRepositoryMock.Setup(x => x.GetActorsSingle(It.IsAny<int>())).ReturnsAsync(var);


            var actorService = new MoviesService(fakeRepositoryMock.Object);

            var result = await actorService.GetActorsSingle(3);

            Assert.Equal("Ham Ham", result.Name);
        }

        [Fact]
        public async Task AddAndSaveEntityTest()
        {
            var fakeRepository = Mock.Of<IActorsContext>();
            var actorService = new ActorsService(fakeRepository);
            await actorService.AddAndSaveActor(var);
        }


        [Fact]
        public async Task SetEntityTest()
        {
            var fakeRepository = Mock.Of<IActorsContext>();
            var actorService = new ActorsService(fakeRepository);
            await actorService.SetActor(var);
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IActorsContext>();
            fakeRepositoryMock.Setup(x => x.GetActorsList()).ReturnsAsync(vars);


            var actorService = new ActorsService(fakeRepositoryMock.Object);
            
            await actorService.DeleteActor(2);
        }
    }
}