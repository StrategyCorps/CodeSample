using Newtonsoft.Json;

namespace StrategyCorps.CodeSample.Dispatchers.Providers.TheMovieDB.Model
{
    public class MovieTitle
    {
        [JsonProperty("iso_3166_1", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
