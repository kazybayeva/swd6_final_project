
	using F1Schedule.Data;
using F1Schedule.Models.ProfileInfoes;
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
        List<ProfileInfo> vars = new List<ProfileInfo>
            {
                new ProfileInfo() { Id = 1, Name = "Seb Seb"},
                new ProfileInfo() { Id = 2, Name = "Ham Ham"},
            };
        ProfileInfo var = new ProfileInfo() { Id = 3, Name = "Ham Ham" };
        [Fact]
        public async Task GetEntityListTest()
        {
            var fakeRepositoryMock = new Mock<IAwardsContext>();
            fakeRepositoryMock.Setup(x => x.GetAwardsList()).ReturnsAsync(vars);


            var profileInfoesService = new AwardsService(fakeRepositoryMock.Object);


            var result = await profileInfoesService.GetAwardsList();

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
            var fakeRepositoryMock = new Mock<IProfileInfoesContext>();
            fakeRepositoryMock.Setup(x => x.GetProfileInfoesSingle(It.IsAny<int>())).ReturnsAsync(var);


            var profileInfoesService = new ProfileInfoesService(fakeRepositoryMock.Object);

            var result = await profileInfoesService.GetProfileInfoesSingle(3);

            Assert.Equal("Ham Ham", result.Name);
        }

        [Fact]
        public async Task AddAndSaveEntityTest()
        {
            var fakeRepository = Mock.Of<IProfileInfoesContext>();
            var profileInfoesService = new ProfileInfoesService(fakeRepository);
            await profileInfoesService.AddAndSaveProfileInfo(var);
        }


        [Fact]
        public async Task SetEntityTest()
        {
            var fakeRepository = Mock.Of<IProfileInfoesContext>();
            var profileInfoesService = new ProfileInfoesService(fakeRepository);
            await profileInfoesService.SetAward(var);
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IProfileInfoesContext>();
            fakeRepositoryMock.Setup(x => x.GetProfileInfoesList()).ReturnsAsync(vars);


            var profileInfoesService = new AwardsService(fakeRepositoryMock.Object);
            
            await profileInfoesService.DeleteProfileInfo(2);
        }
    }
}