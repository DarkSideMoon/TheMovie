using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheMovie.Model.Base;

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
        /// Return list of languages in service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("languages")]
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
    }
}
