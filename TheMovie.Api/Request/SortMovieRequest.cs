using Microsoft.AspNetCore.Mvc;

namespace TheMovie.Api.Request
{
    public class SortMovieRequest : MovieRequest
    {
        /// <summary>
        /// Sort by
        /// </summary>
        [FromQuery(Name = "sortBy")]
        public string SortBy { get; set; }
    }
}
