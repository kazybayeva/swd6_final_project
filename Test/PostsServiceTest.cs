using F1Schedule.Data;
using F1Schedule.Models.Posts;
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
    public class PostsServiceTest
    {
        List<Post> posts = new List<Post>
            {
                new Post() { Id = 1, Number = 5, engineHP = 800, mguHP = 200},
                new Post() { Id = 2, Number = 44, engineHP = 800, mguHP = 200},
            };
        Post post = new Post() { Id = 3, Number = 99, engineHP = 800, mguHP = 200 };
        [Fact]
        public async Task GetEntityListTest()
        {
            var fakeRepositoryMock = new Mock<IPostsContext>();
            fakeRepositoryMock.Setup(x => x.GetPostsList()).ReturnsAsync(cars);


            var postService = new PostService(fakeRepositoryMock.Object);


            var result = await postService.GetPostsList();

            Assert.Collection(result, post =>
            {
                Assert.Equal(5, post.Number);
            },
            post =>
            {
                Assert.Equal(44, post.Number);
            });
        }

        [Fact]
        public async Task GetSingleEntityTest()
        {
            var fakeRepositoryMock = new Mock<IPostsContext>();
            fakeRepositoryMock.Setup(x => x.GetPostsSingle(It.IsAny<int>())).ReturnsAsync(car);


            var postService = new PostsService(fakeRepositoryMock.Object);

            var result = await carService.GetPostsSingle(3);

            Assert.Equal(99, result.Number);
        }

        [Fact]
        public async Task AddAndSaveEntityTest()
        {
            var fakeRepository = Mock.Of<IPostsContext>();
            var postService = new PostService(fakeRepository);
            await postService.AddAndSavePost(post);
        }


        [Fact]
        public async Task SetEntityTest()
        {
            var fakeRepository = Mock.Of<IPostsContext>();
            var postService = new PostService(fakeRepository);
            await postService.SetPost(post);
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IPostsContext>();
            fakeRepositoryMock.Setup(x => x.GetPostsList()).ReturnsAsync(cars);


            var postService = new PostsService(fakeRepositoryMock.Object);
            
            await postService.DeletePost(2);
        }
    }
}