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
    /// Configurations data for application
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ConfigurationController : Controller
    {
        /// <summary>
        /// Client for movie service
        /// </summary>
        private readonly IClient _client;

        /// <summary>
        /// The constructor of configurations
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ConfigurationController(IServiceProvider serviceProvider)
        {
            _client = serviceProvider.GetService<IClient>();
        }

        /// <summary>
        /// Return list of languages in service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("languages")]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(List<Language>), 200)]
        public IActionResult GetLanguages()
        {
            var languages = new List<Language>()
            {
                new Language("English", LanguageType.English, ""),
                new Language("Ukrainian", LanguageType.Ukrainian, ""),
                new Language("Italian", LanguageType.Italian, ""),
                new Language("French", LanguageType.French, ""),
                new Language("German", LanguageType.German, ""),
                new Language("Spanish", LanguageType.Spanish, ""),
                new Language("Russian", LanguageType.Russian, "")
            };

            return Ok(languages);
        }

        /// <summary>
        /// Return list of genres in service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("genres")]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(List<Genre>), 200)]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _client.GetGenresAsync(LanguageType.English);
            return Ok(genres);
        }
    }
}
