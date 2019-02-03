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
            return await _client.GetMovieAsync(id, LanguageType.English);
        }
    }
}
