namespace StrategyCorps.CodeSample.WebApi.ViewModels.Movies
{
    /// <summary>
    ///  The result contained in the response of the movie alternative title search request
    /// </summary>
    public class MovieTitleViewModel
    {
        /// <summary>
        ///  The country code associated with the movie title
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        ///  The movie title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///  The type of the movie title
        /// </summary>
        public string Type { get; set; }
    }
}