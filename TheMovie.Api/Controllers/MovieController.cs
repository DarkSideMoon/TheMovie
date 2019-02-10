using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Api.Filters;
using TheMovie.Model.Base;
using TheMovie.Model.Infrastructure;
using TheMovie.Model.Interfaces;

namespace TheMovie.Api.Controllers
{
    /// <summary>
    /// Movie controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        /// <summary>
        /// MovieSettings for movie service
        /// </summary>
        private readonly MovieSettings _movieSettings;

        /// <summary>
        /// Client for movie service
        /// </summary>
        private readonly IClient _client;

        /// <summary>
        /// Movie constructor
        /// </summary>
        /// <param name="configurationOption">MovieSettings of service</param>
        /// <param name="serviceProvider">Service provider for DI</param>
        public MovieController(IOptions<MovieSettings> configurationOption, IServiceProvider serviceProvider)
        {
            _movieSettings = configurationOption.Value;

            _client = serviceProvider.GetService<IClient>();
        }

        /// <summary>
        /// Get Movie by id
        /// </summary>
        /// <param name="id">Id of movie</param>
        /// <returns></returns>
        [HttpGet]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(Movie), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _client.GetMovieAsync(id, LanguageType.English);
            return Ok(movie);
        }

        /// <summary>
        /// Get Movie by id and language
        /// </summary>
        /// <param name="id">Id of movie</param>
        /// <param name="language">Language of client</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getByLanguage")]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(Movie), 200)]
        public async Task<IActionResult> Get(int id, string language)
        {
            var movie = await _client.GetMovieAsync(id, language);
            return Ok(movie);
        }

        /// <summary>
        /// Get popular movie by genre
        /// </summary>
        /// <param name="genre">Genre</param>
        /// <param name="language">Language of client</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getPopularMoviesByGenre")]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(List<ShortMovie>), 200)]
        public async Task<IActionResult> GetPopularMoviesByGenre(int genre, string language)
        {
            var movies = await _client.GetPopularMoviesByGenreAsync(genre, language);
            return Ok(movies);
        }

        /// <summary>
        /// Get popular movie by genre with year
        /// </summary>
        /// <param name="genre">Genre</param>
        /// <param name="year">Year of release movie</param>
        /// <param name="language">Language of client</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getPopularMoviesByGenreWithYear")]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(List<ShortMovie>), 200)]
        public async Task<IActionResult> GetPopularMoviesByGenreWithYear(int genre, int year, string language)
        {
            var movies = await _client.GetPopularMoviesByGenreWithYearAsync(genre, year, language);
            return Ok(movies);
        }

        /// <summary>
        /// Get best movie by the year
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="year"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getBestMoviesByYear")]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(List<ShortMovie>), 200)]
        public async Task<IActionResult> GetBestMoviesByYearAsync(int genre, int year, string language)
        {
            var movies = await _client.GetBestMoviesByYearAsync(genre, year, language);
            return Ok(movies);
        }
    }
}
