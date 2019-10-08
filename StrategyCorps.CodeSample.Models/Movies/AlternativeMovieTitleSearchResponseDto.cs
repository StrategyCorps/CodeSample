using StrategyCorps.CodeSample.Models.Movies;
using System.Collections.Generic;

namespace StrategyCorps.CodeSample.Models
{
    public class AlternativeMovieTitleSearchResponseDto
    {
        public int Id { get; set; }
        public IList<MovieTitleDto> Titles { get; set; }
    }
}
