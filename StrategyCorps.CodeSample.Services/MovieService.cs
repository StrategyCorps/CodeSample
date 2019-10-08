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
        /// Gets movies that meet the query criteria
        /// </summary>
        /// <param name="query">The criteria used to search for television shows</param>
        /// <returns cref="MovieSearchResponseDto"></returns>
        public MovieSearchResponseDto GetMoviesByQuery(string query)
        {
            return _entertainmentDispatcher.GetMoviesByQuery(query);
        }

        /// <summary>
        /// Gets television shows that are similar to the television show whose id is passed in.
        /// </summary>
        /// <param name="id">The id of the television show used to find similar television shows.</param>
        /// <returns cref="MovieSearchResponseDto"></returns>
        public MovieSearchResponseDto GetSimilarMoviesById(int id)
        {
            return _entertainmentDispatcher.GetSimilarMoviesById(id);
        }
    }
}
