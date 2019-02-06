using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Model.Base;
using TheMovie.Model.Infrastructure;
using TheMovie.Model.Interfaces;
using TheMovie.Model.TMDb;

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
        /// Movie controller
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
        [ProducesResponseType(typeof(Movie), 200)]
        public async Task<Movie> Get(int id)
        {
            try
            {
                return await _client.GetMovieAsync(id, LanguageType.English);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Movie by id and language
        /// </summary>
        /// <param name="id">Id of movie</param>
        /// <param name="language">Language of client</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getByLanguage")]
        [ProducesResponseType(typeof(Movie), 200)]
        public async Task<Movie> Get(int id, string language)
        {
            try
            {
                return await _client.GetMovieAsync(id, LanguageType.English);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get popular movie by genre
        /// </summary>
        /// <param name="genre">Genre</param>
        /// <param name="language">Language of client</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getPopularMoviesByGenre")]
        [ProducesResponseType(typeof(List<Movie>), 200)]
        public async Task<IEnumerable<Movie>> GetPopularMoviesByGenre(int genre, string language)
        {
            try
            {
                return await _client.GetPopularMoviesByGenreAsync(genre, language);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get popular movie by genre
        /// </summary>
        /// <param name="genre">Genre</param>
        /// <param name="year">Year of release movie</param>
        /// <param name="language">Language of client</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getPopularMoviesByGenreWithYear")]
        [ProducesResponseType(typeof(List<Movie>), 200)]
        public async Task<IEnumerable<Movie>> GetPopularMoviesByGenreWithYear(int genre, int year, string language)
        {
            try
            {
                return await _client.GetPopularMoviesByGenreWithYearAsync(genre, year, language);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
