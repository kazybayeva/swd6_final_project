using F1Schedule.Data;
using F1Schedule.Models.Users;
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
        List<User> vars = new List<User>
            {
                new User() { Id = 1, Name = "Seb Seb"},
                new User() { Id = 2, Name = "Ham Ham"},
            };
        User var = new User() { Id = 3, Name = "Ham Ham" };
        [Fact]
        public async Task GetEntityListTest()
        {
            var fakeRepositoryMock = new Mock<IUsersContext>();
            fakeRepositoryMock.Setup(x => x.GetUsersList()).ReturnsAsync(vars);


            var userService = new UsersService(fakeRepositoryMock.Object);


            var result = await userService.GetUsersList();

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
            var fakeRepositoryMock = new Mock<IUsersContext>();
            fakeRepositoryMock.Setup(x => x.GetUsersSingle(It.IsAny<int>())).ReturnsAsync(var);


            var userService = new UsersService(fakeRepositoryMock.Object);

            var result = await userService.GetUsersSingle(3);

            Assert.Equal("Ham Ham", result.Name);
        }

        [Fact]
        public async Task AddAndSaveEntityTest()
        {
            var fakeRepository = Mock.Of<IUsersContext>();
            var userService = new UsersService(fakeRepository);
            await userService.AddAndSaveUser(var);
        }


        [Fact]
        public async Task SetEntityTest()
        {
            var fakeRepository = Mock.Of<IUsersContext>();
            var userService = new UsersService(fakeRepository);
            await userService.SetUser(var);
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IUsersContext>();
            fakeRepositoryMock.Setup(x => x.GetUsersList()).ReturnsAsync(vars);


            var userService = new UsersService(fakeRepositoryMock.Object);
            
            await userService.DeleteUser(2);
        }
    }
}