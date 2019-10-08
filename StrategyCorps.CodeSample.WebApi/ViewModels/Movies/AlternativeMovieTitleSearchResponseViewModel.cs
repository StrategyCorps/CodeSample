using StrategyCorps.CodeSample.Models.Movies;
using System.Collections.Generic;

namespace StrategyCorps.CodeSample.WebApi.ViewModels.Movies
{
    /// <summary>
    /// The response from the movie alternative title search request
    /// </summary>
    public class AlternativeMovieTitleSearchResponseViewModel
    {
        /// <summary>
        /// The unique identifier of the movie
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The alternative movie titles
        /// </summary>
        public IList<MovieTitleViewModel> Titles { get; set; }
    }
}