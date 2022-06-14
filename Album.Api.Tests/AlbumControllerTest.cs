using Album.Api.Controllers;
using Album.Api.Services;
using Album.Api.Data;
using System;
using System.Net;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Album.Api.Tests
{
    public class AlbumControllerTest
    {
        private readonly AlbumController _controller;
        private readonly IAlbumService<Models.Album> _service;
        public AlbumControllerTest()
        {
            _service = new AlbumServiceOther();
            _controller = new AlbumController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Models.Album>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }


        /*[Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(12);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }*/

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = 2;

            // Act
            var okResult = _controller.Get(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = 1;

            // Act
            var okResult = _controller.Get(testGuid) as OkObjectResult;

            // Assert
            Assert.IsType<Models.Album>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as Models.Album).Id);
        }

        /*[Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Models.Album()
            {
                Artist = "Guinness",
                Name = "hello"
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        */

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Models.Album testItem = new Models.Album()
            {
                Name = "Guinness Original 6 Pack",
                Artist = "Guinness",
                ImageUrl = "nothing.com"
            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        /*[Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Models.Album()
            {
                Name = "Guinness Original 6 Pack",
                Artist = "Guinness",
                ImageUrl = "google.com"
            };

            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Models.Album;

            // Assert
            Assert.IsType<Models.Album>(item);
            Assert.Equal("Guinness Original 6 Pack", item.Name);
        }*/
        


        /*[Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = 15;

            // Act
            var badResponse = _controller.Delete(notExistingGuid);

            // Assert
            Assert.IsType<NoContentResult>(badResponse);
        }*/

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingGuid = 1;

            // Act
            var noContentResponse = _controller.Delete(existingGuid);

            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = 3;

            // Act
            var okResponse = _controller.Delete(existingGuid);

            // Assert
            Assert.Equal(2, _service.GetAlbums().Count());
        }

    }
}
