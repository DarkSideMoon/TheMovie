using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Model.Base;
using TheMovie.Model.Common;
using TheMovie.Model.Interfaces;

namespace TheMovie.Api.Controllers
{
    /// <summary>
    /// Configurations data for application
    /// </summary>
    [ApiController]
    [Route("configuration")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ConfigurationController : ControllerBase
    {
        /// <summary>
        /// Client for movie service
        /// </summary>
        private readonly IClient _client;

        /// <summary>
        /// The constructor of configurations
        /// </summary>
        /// <param name="client"></param>
        public ConfigurationController(IClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Return list of languages in service
        /// </summary>
        /// <returns>Return find genres</returns>
        /// <response code="200">Return find genres</response>
        [HttpGet]
        [Route("languages")]
        [ProducesResponseType(typeof(List<Language>), 200)]
        public IActionResult GetLanguages()
        {
            var languages = new List<Language>()
            {
                new Language("English", LanguageType.English, string.Empty),
                new Language("Ukrainian", LanguageType.Ukrainian, string.Empty),
                new Language("Italian", LanguageType.Italian, string.Empty),
                new Language("French", LanguageType.French, string.Empty),
                new Language("German", LanguageType.German, string.Empty),
                new Language("Spanish", LanguageType.Spanish, string.Empty),
                new Language("Russian", LanguageType.Russian, string.Empty)
            };

            return Ok(languages);
        }

        /// <summary>
        /// Return list of genres in service
        /// </summary>
        /// <returns>Return find genres</returns>
        /// <response code="200">Return find genres</response>
        /// <response code="500">Internal server error</response>    
        [HttpGet]
        [Route("genres")]
        [ProducesResponseType(typeof(List<Genre>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _client.GetGenresAsync(LanguageType.English);
            return Ok(genres);
        }
    }
}
