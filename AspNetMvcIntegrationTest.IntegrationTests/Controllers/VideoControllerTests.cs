using AspNetMvcIntegrationTest.Data.Models;
using AspNetMvcIntegrationTest.Data.UnitOfWork;
using AspNetMvcIntegrationTest.Web.Controllers;
using AspNetMvcIntegrationTest.Web.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcIntegrationTest.IntegrationTests.Controllers
{
    [TestFixture]
    public class VideoControllerTests
    {
        private UnitOfWork _unitOfWork;
        private VideoController _sut;

        [SetUp]
        public void Initialize()
        {
            _unitOfWork = new UnitOfWork();
            _sut = new VideoController(_unitOfWork);
        }

        [Test]
        public void Index_ValidRequest_ReturnsVideos()
        {
            // Arrange
            var video = new Video
            {
                Title = "Why humans run the world | Yuval Noah Harari",
                Url = "https://www.youtube.com/watch?v=nzj7Wg4DAbs",
                Duration = 1029,
                UploadTime = DateTime.Now,
                ViewCount = 123456
            };
            _unitOfWork.Videos.Add(video);
            _unitOfWork.Complete();

            // Act
            var result = _sut.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<IEnumerable<Video>>(result.Model);
            Assert.AreEqual(video.VideoId, ((IEnumerable<Video>)result.Model).First().VideoId);
        }

        [Test, Isolated]
        public void Details_ValidRequest_ReturnsVideo()
        {
            // Arrange
            var video = new Video
            {
                Title = "Why humans run the world | Yuval Noah Harari",
                Url = "https://www.youtube.com/watch?v=nzj7Wg4DAbs",
                Duration = 1029,
                UploadTime = new DateTime(2015, 6, 1),
                ViewCount = 123456
            };
            _unitOfWork.Videos.Add(video);
            _unitOfWork.Complete();

            // Act
            var result = _sut.Details(video.VideoId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult) result;
            Assert.IsInstanceOf<Video>(viewResult.Model);
            Assert.AreEqual(video.VideoId, ((Video)viewResult.Model).VideoId);
        }

        [Test]
        public void Stats_ValidRequest_ReturnsVideoStatsViewModel()
        {
            // Arrange

            // Act
            var result = _sut.Stats();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<VideoStatsViewModel>(result.Model);
        }
    }
}
