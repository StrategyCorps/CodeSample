using System.Globalization;
using System.Linq;
using AutoMapper;
using ExpectedObjects;
using FizzWare.NBuilder;
using NUnit.Framework;
using StrategyCorps.CodeSample.Models;
using StrategyCorps.CodeSample.Models.Movies;
using StrategyCorps.CodeSample.WebApi.MappingProfiles;
using StrategyCorps.CodeSample.WebApi.ViewModels;
using StrategyCorps.CodeSample.WebApi.ViewModels.Movies;

namespace StrategyCorps.CodeSample.WebApi.Tests.MappingProfiles
{
    [TestFixture]
    public class DefaultMappingProfileTests
    {
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<DefaultMappingProfile>(); });
            _mapper = config.CreateMapper();
        }

        [TearDown]
        public void TearDown()
        {
            _mapper = null;
        }

        [Test]
        public void DefaultMappingProfile_When_TelevisionSearchResponseDTO_Returns_TelevisionSearchResponseViewModel()
        {
            var televisionResultsDto = Builder<TelevisionResultDto>.CreateListOfSize(5).Build().ToList();
            var televisionSearchResponseDto = Builder<TelevisionSearchResponseDto>.CreateNew()
                .With(x => x.Results = televisionResultsDto).Build();

            var televisionResultsViewModel = televisionResultsDto.Select(televisionResultDto => new TelevisionResultViewModel
            {
                FirstAirDate = televisionResultDto.FirstAirDate.ToString(CultureInfo.InvariantCulture),
                Id = televisionResultDto.Id,
                Name = televisionResultDto.Name,
                OriginalLanguage = televisionResultDto.OriginalLanguage,
                OriginalName = televisionResultDto.OriginalName,
                Overview = televisionResultDto.Overview,
                Popularity = televisionResultDto.Popularity,
                VoteAverage = televisionResultDto.VoteAverage,
                VoteCount = televisionResultDto.VoteCount
            }).ToList();

            var expectedResult = Builder<TelevisionSearchResponseViewModel>.CreateNew()
                .With(x => x.Page = televisionSearchResponseDto.Page)
                .With(x => x.TotalPages = televisionSearchResponseDto.TotalPages)
                .With(x => x.TotalResults = televisionSearchResponseDto.TotalResults)
                .With(x => x.Results = televisionResultsViewModel).Build();

            var actualResult = _mapper.Map<TelevisionSearchResponseDto, TelevisionSearchResponseViewModel>(televisionSearchResponseDto);

            actualResult.ToExpectedObject().ShouldEqual(expectedResult);
        }

        [Test]
        public void DefaultMappingProfile_When_TelevisionResultDTO_Returns_TelevisionResultViewModel()
        {
            var televisionResultDto = Builder<TelevisionResultDto>.CreateNew().Build();
            var expectedResult = Builder<TelevisionResultViewModel>.CreateNew()
                .With(x => x.OriginalLanguage = televisionResultDto.OriginalLanguage)
                .With(x => x.FirstAirDate = televisionResultDto.FirstAirDate.ToString(CultureInfo.InvariantCulture))
                .With(x => x.Id = televisionResultDto.Id)
                .With(x => x.Name = televisionResultDto.Name)
                .With(x => x.OriginalName = televisionResultDto.OriginalName)
                .With(x => x.Overview = televisionResultDto.Overview)
                .With(x => x.Popularity = televisionResultDto.Popularity)
                .With(x => x.VoteAverage = televisionResultDto.VoteAverage)
                .With(x => x.VoteCount = televisionResultDto.VoteCount).Build();

            var actualResult = _mapper.Map<TelevisionResultDto, TelevisionResultViewModel>(televisionResultDto);

            actualResult.ToExpectedObject().ShouldEqual(expectedResult);
        }

        [Test]
        public void DefaultMappingProfile_When_MovieTitleDTO_Returns_MovieTitleViewModel()
        {
            var movieTitleDto = Builder<MovieTitleDto>.CreateNew().Build();
            var expectedResult = Builder<MovieTitleViewModel>.CreateNew()
                .With(x => x.CountryCode = movieTitleDto.CountryCode)
                .With(x => x.Title = movieTitleDto.Title)
                .With(x => x.Type = movieTitleDto.Type).Build();

            var actualResult = _mapper.Map<MovieTitleDto, MovieTitleViewModel>(movieTitleDto);

            actualResult.ToExpectedObject().ShouldEqual(expectedResult);
        }

        [Test]
        public void DefaultMappingProfile_When_AlternativeMovieTitleSearchResultDTO_Returns_AlternativeMovieTitleSearchResponseViewModel()
        {
            var movieTitleDtos = Builder<MovieTitleDto>.CreateListOfSize(5).Build().ToList();
            var movieTitleSearchResponseDto = Builder<AlternativeMovieTitleSearchResponseDto>.CreateNew()
                .With(x => x.Titles = movieTitleDtos).Build();

            var movieTitlesViewModel = movieTitleDtos.Select(dto => new MovieTitleViewModel
            {
                CountryCode = dto.CountryCode,
                Title = dto.Title,
                Type = dto.Type
            }).ToList();

            var expectedResult = Builder<AlternativeMovieTitleSearchResponseViewModel>.CreateNew()
                .With(x => x.Id = movieTitleSearchResponseDto.Id)
                .With(x => x.Titles = movieTitlesViewModel).Build();

            var actualResult = _mapper.Map<AlternativeMovieTitleSearchResponseDto, AlternativeMovieTitleSearchResponseViewModel>(movieTitleSearchResponseDto);

            actualResult.ToExpectedObject().ShouldEqual(expectedResult);
        }
    }
}
