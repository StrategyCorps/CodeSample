using StrategyCorps.CodeSample.Models;

namespace StrategyCorps.CodeSample.Interfaces.Services
{
    public interface IMovieService
    {
        AlternativeMovieTitleSearchResponseDto GetAlternativeMovieTitlesById(int id);
    }
}
