using Newtonsoft.Json;

namespace TheMovie.Api.Request
{
    public class SearchRequest
    {
        /// <summary>
        /// Name of the movie to search 
        /// </summary>
        [JsonProperty("queryName")]
        public string QueryName { get; set; }

        /// <summary>
        /// Language of the movie
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// Is movie adult
        /// </summary>
        [JsonProperty("isAdult")]
        public bool IsAdult { get; set; }

        /// <summary>
        /// Region of the movie
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Year of the movie
        /// </summary>
        [JsonProperty("year")]
        public string Year { get; set; }
    }
}
