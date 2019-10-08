using System.Collections.Generic;

namespace StrategyCorps.CodeSample.Models
{
    public class MovieSearchResponseDto
    {
        public IList<MovieResultDto> Results { set; get; }

        public int Page { get; set; }

        public int TotalResults { get; set; }

        public int TotalPages { get; set; }
    }
}
