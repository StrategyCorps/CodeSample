using System.Collections.Generic;

namespace StrategyCorps.CodeSample.WebApi.ViewModels
{
    /// <summary>
    /// The response from the movie search request
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MovieSearchResponseViewModel
    {
        /// <summary>
        /// The results of the television search request
        /// </summary>
        public IList<MovieResultViewModel> Results { get; set; }

        /// <summary>
        /// The page number of the results
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The total number of results
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// The total number of pages
        /// </summary>
        public int TotalPages { get; set; }
    }
}
