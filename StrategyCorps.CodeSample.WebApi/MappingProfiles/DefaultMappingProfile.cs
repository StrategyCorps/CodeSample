using System.Globalization;
using AutoMapper;
using StrategyCorps.CodeSample.Models;
using StrategyCorps.CodeSample.Models.Movies;
using StrategyCorps.CodeSample.WebApi.ViewModels;
using StrategyCorps.CodeSample.WebApi.ViewModels.Movies;

namespace StrategyCorps.CodeSample.WebApi.MappingProfiles
{
    /// <summary>
    /// The WebApi default mapping profiles
    /// </summary>
    public class DefaultMappingProfile : Profile
    {
        /// <summary>
        /// The  WebApi default mapping profile constructor
        /// </summary>
        public DefaultMappingProfile()
        {
            CreateMap<TelevisionResultDto, TelevisionResultViewModel>()
                .ForMember(destination => destination.FirstAirDate, options => options.MapFrom(source => source.FirstAirDate.ToString(CultureInfo.InvariantCulture)));
            CreateMap<TelevisionSearchResponseDto, TelevisionSearchResponseViewModel>();
            CreateMap<MovieTitleDto, MovieTitleViewModel>();
            CreateMap<AlternativeMovieTitleSearchResponseDto, AlternativeMovieTitleSearchResponseViewModel>();
        }
    }
}
