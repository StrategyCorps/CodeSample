using StrategyCorps.CodeSample.Models;

namespace StrategyCorps.CodeSample.Interfaces.Services
{
    public interface IMovieService
    {
        MovieSearchResponseDto GetMoviesByQuery(string query);

        MovieSearchResponseDto GetSimilarMoviesById(int id);
    }
}
