using Microsoft.AspNetCore.Mvc;

namespace TheMovie.Api.Request
{
    public class MovieRequest
    {
        /// <summary>
        /// Genge of the movie
        /// </summary>
        [FromQuery(Name = "genre")]
        public int Genre { get; set; }

        /// <summary>
        /// Year of the movie
        /// </summary>
        [FromQuery(Name = "year")]
        public int Year { get; set; }

        /// <summary>
        /// Language of the movie
        /// </summary>
        [FromQuery(Name = "language")]
        public string Language { get; set; }
    }
}
