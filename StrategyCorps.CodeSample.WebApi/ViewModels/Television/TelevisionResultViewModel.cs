namespace StrategyCorps.CodeSample.WebApi.ViewModels
{
    /// <summary>
    ///  The result contained in the response of the television search request
    /// </summary>
    public class TelevisionResultViewModel
    {
        /// <summary>
        /// The popularity of the television show
        /// </summary>
        public decimal Popularity { get; set; }

        /// <summary>
        /// The unique identifier of the television show
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The average vote for the television show
        /// </summary>
        public decimal VoteAverage { get; set; }

        /// <summary>
        /// The overview of the television show
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// The first air date of the television show
        /// </summary>
        public string FirstAirDate { get; set; }
        
        /// <summary>
        /// The original language of the television show
        /// </summary>
        public string OriginalLanguage { get; set; }

        /// <summary>
        /// The number of votes for the television show
        /// </summary>
        public int VoteCount { get; set; }

        /// <summary>
        /// The name of the television show
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The original name of the television show
        /// </summary>
        public string OriginalName { get; set; }
    }
}
