using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheMovie.Model.Base;
using TheMovie.Model.Common;
using TheMovie.Model.Interfaces;

namespace TheMovie.Api.Controllers
{
    /// <summary>
    /// Random controller
    /// </summary>
    [ApiController]
    [Route("random")]
    [Produces(MediaTypeNames.Application.Json)]
    public class RandomController : ControllerBase
    {
        /// <summary>
        /// Client for movie service
        /// </summary>
        private readonly IClient _client;

        /// <summary>
        /// The constructor of configurations
        /// </summary>
        /// <param name="client"></param>
        public RandomController(IClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get best movie by the year
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="year"></param>
        /// <param name="language"></param>
        /// <returns>Return random movie</returns>
        /// <response code="200">Return random movie</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetBestMoviesByYearAsync(int genre, int year, string language)
        {
            // From 1 to 4 pages of movies
            int randomPage = new Random().Next(1, 4);

            // Random movie per one page
            int randomMovie = new Random().Next(1, 20);

            // Get short information about movies
            var movies = await _client.GetPopularMoviesByGenreWithYearPageAsync(genre, year, randomPage, language);

            // Get random movie 
            var shortFindedMovie = movies.ElementAtOrDefault(randomMovie);

            // Get full information of movie
            var movie = await _client.GetMovieAsync(shortFindedMovie.Id, language);

            return Ok(movie);
        }
    }
}
