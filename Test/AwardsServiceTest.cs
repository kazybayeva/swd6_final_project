
	using F1Schedule.Data;
using F1Schedule.Models.Awards;
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
        List<Award> vars = new List<Award>
            {
                new Award() { Id = 1, Name = "Seb Seb"},
                new Award() { Id = 2, Name = "Ham Ham"},
            };
        Award var = new Award() { Id = 3, Name = "Ham Ham" };
        [Fact]
        public async Task GetEntityListTest()
        {
            var fakeRepositoryMock = new Mock<IAwardsContext>();
            fakeRepositoryMock.Setup(x => x.GetAwardsList()).ReturnsAsync(vars);


            var awardService = new AwardsService(fakeRepositoryMock.Object);


            var result = await awardService.GetAwardsList();

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
            var fakeRepositoryMock = new Mock<IAwardsContext>();
            fakeRepositoryMock.Setup(x => x.GetAwardsSingle(It.IsAny<int>())).ReturnsAsync(var);


            var awardService = new AwardsService(fakeRepositoryMock.Object);

            var result = await awardService.GetAwardsSingle(3);

            Assert.Equal("Ham Ham", result.Name);
        }

        [Fact]
        public async Task AddAndSaveEntityTest()
        {
            var fakeRepository = Mock.Of<IAwardsContext>();
            var awardService = new AwardsService(fakeRepository);
            await awardService.AddAndSaveAward(var);
        }


        [Fact]
        public async Task SetEntityTest()
        {
            var fakeRepository = Mock.Of<IAwardsContext>();
            var awardService = new AwardsService(fakeRepository);
            await awardService.SetAward(var);
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IAwardsContext>();
            fakeRepositoryMock.Setup(x => x.GetAwardsList()).ReturnsAsync(vars);


            var awardService = new AwardsService(fakeRepositoryMock.Object);
            
            await awardService.DeleteAward(2);
        }
    }
}