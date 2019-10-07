using System;
using System.Linq;
using System.Net;
using System.Web.Http.Results;
using AutoMapper;
using ExpectedObjects;
using FizzWare.NBuilder;
using Moq;
using NUnit.Framework;
using StrategyCorps.CodeSample.Core.Exceptions;
using StrategyCorps.CodeSample.Interfaces.Services;
using StrategyCorps.CodeSample.Models;
using StrategyCorps.CodeSample.WebApi.Controllers;
using StrategyCorps.CodeSample.WebApi.Tests.Extensions;
using StrategyCorps.CodeSample.WebApi.ViewModels;
using StrategyCorps.CodeSample.WebApi.ViewModels.Movies;
using ILogger = NLog.ILogger;

namespace StrategyCorps.CodeSample.WebApi.Tests.Controllers
{
    [TestFixture]
    public class MovieSearchByQueryTests
    {
        [Test]
        [TestCase(null)]
        [TestCase(0)]
        public void MovieSearchById_When_QueryIsNullOrWhitespace_Returns_BadRequest(int id)
        {
            var movieController = new MovieController(null, null, null);
            var actionResult = movieController.AlternativeMovieTitles(id);

            var response = actionResult.CheckActionResultAndCast<NegotiatedContentResult<string>>();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        [TestCase(42)]
        public void MovieSearchByQuery_When_MovieServiceReturnsNull_Returns_NotFound(int id)
        {
            var logger = new Mock<ILogger>();
            logger.Setup(x => x.Error(It.IsAny<Exception>())).Verifiable();

            var movieServiceMock = new Mock<IMovieService>();
            movieServiceMock.Setup(x => x.GetAlternativeMovieTitlesById(It.IsAny<int>())).Returns((AlternativeMovieTitleSearchResponseDto)null);

            var movieController = new MovieController(movieServiceMock.Object, logger.Object, null);
            var actionResult = movieController.AlternativeMovieTitles(id);

            var response = actionResult.CheckActionResultAndCast<NegotiatedContentResult<string>>();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

            logger.Verify(x => x.Error(It.IsAny<Exception>()), Times.Never);
        }

        [Test]
        [TestCase(420817)]
        public void MovieSearchByQuery_When_MovieServiceThrowsException_Returns_InternalServerError(int id)
        {
            var logger = new Mock<ILogger>();
            logger.Setup(x => x.Error(It.IsAny<Exception>())).Verifiable();

            var movieServiceMock = new Mock<IMovieService>();
            movieServiceMock.Setup(x => x.GetAlternativeMovieTitlesById(It.IsAny<int>())).Throws<Exception>();

            var movieController = new MovieController(movieServiceMock.Object, logger.Object, null);
            var actionResult = movieController.AlternativeMovieTitles(id);

            var response = actionResult.CheckActionResultAndCast<NegotiatedContentResult<string>>();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));

            logger.Verify(x => x.Error(It.IsAny<Exception>()), Times.Once);
        }

        [Test]
        [TestCase(420817)]
        public void MovieSearchByQuery_When_MovieServiceThrowsStrategyCorpsException_Returns_InternalServerError(int id)
        {
            var logger = new Mock<ILogger>();
            logger.Setup(x => x.Error(It.IsAny<Exception>())).Verifiable();

            var movieServiceMock = new Mock<IMovieService>();
            movieServiceMock.Setup(x => x.GetAlternativeMovieTitlesById(It.IsAny<int>())).Throws<StrategyCorpsException>();

            var movieController = new MovieController(movieServiceMock.Object, logger.Object, null);
            var actionResult = movieController.AlternativeMovieTitles(id);

            var response = actionResult.CheckActionResultAndCast<NegotiatedContentResult<string>>();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));

            logger.Verify(x => x.Error(It.IsAny<Exception>()), Times.Once);
        }

        [Test]
        [TestCase(420817)]
        public void MovieSearchByQuery_When_MovieServiceReturnsAlternativeMovieTitleSearchResponseDTO_Returns_Ok(int id)
        {
            var alternativeMovieTitleSearchResponseDto = Builder<AlternativeMovieTitleSearchResponseDto>.CreateNew().Build();
            var movieTitleViewModels = Builder<MovieTitleViewModel>.CreateListOfSize(5).Build();
            var expectedResult = Builder<AlternativeMovieTitleSearchResponseViewModel>.CreateNew()
                .With(x => x.Titles = movieTitleViewModels.ToList()).Build();

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Error(It.IsAny<Exception>())).Verifiable();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<AlternativeMovieTitleSearchResponseDto, AlternativeMovieTitleSearchResponseViewModel>(It.IsAny<AlternativeMovieTitleSearchResponseDto>()))
                .Returns(expectedResult).Verifiable();

            var movieServiceMock = new Mock<IMovieService>();
            movieServiceMock.Setup(x => x.GetAlternativeMovieTitlesById(It.IsAny<int>())).Returns(alternativeMovieTitleSearchResponseDto);

            var movieController = new MovieController(movieServiceMock.Object, loggerMock.Object, mapperMock.Object);
            var actionResult = movieController.AlternativeMovieTitles(id);

            var response = actionResult.CheckActionResultAndCast<OkNegotiatedContentResult<AlternativeMovieTitleSearchResponseViewModel>>();
            response.Content.ToExpectedObject().ShouldEqual(expectedResult);

            loggerMock.Verify(x => x.Error(It.IsAny<Exception>()), Times.Never);
            mapperMock.Verify(x => x.Map<AlternativeMovieTitleSearchResponseDto, AlternativeMovieTitleSearchResponseViewModel>(It.IsAny<AlternativeMovieTitleSearchResponseDto>()), Times.Once);
        }
    }
}
