using Microsoft.AspNetCore.Mvc;

namespace TheMovie.Api.Request
{
    public class GetGenresRequest
    {
        /// <summary>
        /// Language of the genre
        /// </summary>
        [FromQuery(Name = "language")]
        public string Language { get; set; }
    }
}
