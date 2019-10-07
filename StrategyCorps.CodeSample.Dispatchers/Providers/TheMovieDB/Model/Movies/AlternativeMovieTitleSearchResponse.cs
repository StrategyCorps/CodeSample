using Newtonsoft.Json;
using System.Collections.Generic;

namespace StrategyCorps.CodeSample.Dispatchers.Providers.TheMovieDB.Model.Movies
{
    public class AlternativeMovieTitleSearchResponse
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("titles", NullValueHandling = NullValueHandling.Ignore)]
        public IList<MovieTitle> Titles { get; set; }
    }
}
