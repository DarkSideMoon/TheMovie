using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Api.Filters;
using TheMovie.Model.Base;
using TheMovie.Model.Interfaces;

namespace TheMovie.Api.Controllers
{
    /// <summary>
    /// Random controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RandomController : Controller
    {
        /// <summary>
        /// Client for movie service
        /// </summary>
        private readonly IClient _client;

        /// <summary>
        /// The constructor of configurations
        /// </summary>
        /// <param name="serviceProvider"></param>
        public RandomController(IServiceProvider serviceProvider)
        {
            _client = serviceProvider.GetService<IClient>();
        }

        /// <summary>
        /// Get best movie by the year
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="year"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        [HttpGet]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(Movie), 200)]
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
            var movie = _client.GetMovie(shortFindedMovie.Id, language);

            return Ok(movie);
        }
    }
}
