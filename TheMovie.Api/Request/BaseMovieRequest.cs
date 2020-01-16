using Microsoft.AspNetCore.Mvc;

namespace TheMovie.Api.Request
{
    public class BaseMovieRequest
    {
        /// <summary>
        /// Id of movie
        /// </summary>
        [FromQuery(Name = "id")]
        public int Id { get; set; }
    }
}
