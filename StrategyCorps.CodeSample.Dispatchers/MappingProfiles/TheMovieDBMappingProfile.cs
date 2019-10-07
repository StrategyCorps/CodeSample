using System;
using System.Globalization;
using AutoMapper;
using StrategyCorps.CodeSample.Dispatchers.Providers.TheMovieDB.Model;
using StrategyCorps.CodeSample.Dispatchers.Providers.TheMovieDB.Model.Movies;
using StrategyCorps.CodeSample.Models;
using StrategyCorps.CodeSample.Models.Movies;

namespace StrategyCorps.CodeSample.Dispatchers.MappingProfiles
{
    public class TheMovieDbMappingProfile:Profile
    {
        public TheMovieDbMappingProfile()
        {
            CreateMap<TelevisionResult, TelevisionResultDto>()
                .ForMember(destination => destination.FirstAirDate, options => options.MapFrom(source => DateTime.Parse(source.FirstAirDate, CultureInfo.CurrentCulture)));
            CreateMap<TelevisionSearchResponse, TelevisionSearchResponseDto>();
            CreateMap<MovieTitle, MovieTitleDto>();
            CreateMap<AlternativeMovieTitleSearchResponse, AlternativeMovieTitleSearchResponseDto>();
        }
    }
}
