using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HGBlog.Dtos;
using HGBlog.Logic;
using HGBlogApi.Controllers.api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace HGBlog.Test.Controllers
{
    [TestClass]
    public class PostsControllerTest
    {
        [Fact]
        [Trait("Post COntrollers test", "Test DeletePost")]
        public async void Delete_Post_Get_OK()
        {

            ///Arrange
            var mockLogic = new Mock<IPostLogic>();
            mockLogic.Setup(t => t.DeletePost(It.IsAny<int>())).Returns(Task.FromResult(true));

            var controller = new PostsController(mockLogic.Object);


            ///Act
            IActionResult result = await controller.DeletePost(1);
            var controllerResult = result as OkObjectResult;


            ///Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.True(controllerResult?.StatusCode == 200);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [Trait("Post COntrollers test", "Test GetPostsByState")]
        public async void GetPostsByStatet_Get_OK(int state)
        {

            ///Arrange
            var mockLogic = new Mock<IPostLogic>();
            var mockResult = new List<Post>();
            mockResult.Add(new Post()
            {
                Id = 1,
                TitlePost = "Title mock 1",
                PostText = " text of post"
            });

            mockLogic.Setup(t => t.GetPostsByState(It.IsAny<int>())).ReturnsAsync(mockResult);

            var controller = new PostsController(mockLogic.Object);


            ///Act
            IActionResult result = await controller.GetPostsByState(state);
            var controllerResult = result as OkObjectResult;


            ///Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.True(controllerResult?.StatusCode == 200);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [Trait("Post COntrollers test", "Test GetPostsByState")]
        public async void GetPostsByStatet_Get_NoContent(int state)
        {

            ///Arrange
            var mockLogic = new Mock<IPostLogic>();
            var mockResult = new List<Post>();

            mockLogic.Setup(t => t.GetPostsByState(It.IsAny<int>())).ReturnsAsync(mockResult);

            var controller = new PostsController(mockLogic.Object);


            ///Act
            IActionResult result = await controller.GetPostsByState(state);
            var controllerResult = result as NoContentResult;


            ///Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.True(controllerResult?.StatusCode == 204);
        }
    }
}
