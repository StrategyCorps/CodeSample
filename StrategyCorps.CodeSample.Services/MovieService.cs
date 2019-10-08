using StrategyCorps.CodeSample.Interfaces.Dispatchers;
using StrategyCorps.CodeSample.Interfaces.Services;
using StrategyCorps.CodeSample.Models;

namespace StrategyCorps.CodeSample.Services
{
    public class MovieService : IMovieService
    {
        private readonly IEntertainmentDispatcher _entertainmentDispatcher;

        public MovieService(IEntertainmentDispatcher entertainmentDispatcher)
        {
            _entertainmentDispatcher = entertainmentDispatcher;
        }

        /// <summary>
        /// Gets alternative titles for the movie whose id is passed in.
        /// </summary>
        /// <param name="id">The id of the movie used to find its alternative titles</param>
        /// <returns cref="AlternativeMovieTitleSearchResponseDto"></returns>
        public AlternativeMovieTitleSearchResponseDto GetAlternativeMovieTitlesById(int id)
        {
            return _entertainmentDispatcher.GetAlternativeMovieTitlesById(id);
        }
    }
}
