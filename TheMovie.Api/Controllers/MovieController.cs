using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using TheMovie.Api.Request;
using TheMovie.Model.Base;
using TheMovie.Model.Common;
using TheMovie.Model.Interfaces;

namespace TheMovie.Api.Controllers
{
    /// <summary>
    /// Movie controller
    /// </summary>
    [ApiController]
    [Route("movie")]
    [Produces(MediaTypeNames.Application.Json)]
    public class MovieController : ControllerBase
    {
        /// <summary>
        /// Client for movie service
        /// </summary>
        private readonly IClient _client;

        /// <summary>
        /// Movie constructor
        /// </summary>
        /// <param name="client">Client</param>
        public MovieController(IClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get Movie by id
        /// </summary>
        /// <param name="movieRequest">Id of movie</param>
        /// <returns>Return movie by id</returns>
        /// <response code="200">Return movie</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> Get([FromQuery] BaseMovieRequest movieRequest)
        {
            var movie = await _client.GetMovieAsync(movieRequest.Id, LanguageType.English);
            return Ok(movie);
        }

        /// <summary>
        /// Get Movie by id and language
        /// </summary>
        /// <param name="id">Id of movie</param>
        /// <param name="language">Language of client</param>
        /// <returns>Return movie by language</returns>
        /// <response code="200">Return movie</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("getByLanguage")]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
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
        /// <returns>Return popular movie</returns>
        /// <response code="200">Return movie</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("getPopularMoviesByGenre")]
        [ProducesResponseType(typeof(List<ShortMovie>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetPopularMoviesByGenre(int genre, string language)
        {
            var movies = await _client.GetPopularMoviesByGenreAsync(genre, language);
            return Ok(movies);
        }

        /// <summary>
        /// Get popular movie by genre with year
        /// </summary>
        /// <param name="movieRequest"></param>
        /// <returns>Return popular movie</returns>
        /// <response code="200">Return movie</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("getPopularMoviesByGenreWithYear")]
        [ProducesResponseType(typeof(List<ShortMovie>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetPopularMoviesByGenreWithYear([FromQuery] MovieRequest movieRequest)
        {
            var movies = 
                await _client.GetPopularMoviesByGenreWithYearAsync(movieRequest.Genre, movieRequest.Year, movieRequest.Language);
            return Ok(movies);
        }

        /// <summary>
        /// Get best movie by the year
        /// </summary>
        /// <param name="movieRequest"></param>
        /// <returns>Return best movie</returns>
        /// <response code="200">Return movie</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("getBestMoviesByYear")]
        [ProducesResponseType(typeof(List<ShortMovie>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetBestMoviesByYearAsync([FromQuery] MovieRequest movieRequest)
        {
            var movies = await _client.GetBestMoviesByYearAsync(movieRequest.Genre, movieRequest.Year, movieRequest.Language);
            return Ok(movies);
        }
    }
}
