using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using TheMovie.Api.Request;
using TheMovie.Model.Base;
using TheMovie.Model.Common;
using TheMovie.Service.Service.Settings;
using TheMovie.Service.ViewModel;

namespace TheMovie.Api.Controllers
{
    /// <summary>
    /// Configurations data for application
    /// </summary>
    [ApiController]
    [Route("settings")]
    [Produces(MediaTypeNames.Application.Json)]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _settingsService;

        private readonly IMapper _mapper;

        /// <summary>
        /// The constructor of configurations
        /// </summary>
        /// <param name="settingsService"></param>
        /// <param name="mapper"></param>
        public SettingsController(ISettingsService settingsService, IMapper mapper)
        {
            _settingsService = settingsService;
            _mapper = mapper;
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
            var languages = _settingsService.GetLanguages();
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
        public async Task<IActionResult> GetGenres(GetGenresRequest getGenresRequest)
        {
            var genreViewModel = _mapper.Map<GenreViewModel>(getGenresRequest);

            var genres = await _settingsService.GetGenresAsync(genreViewModel);
            return Ok(genres);
        }
    }
}
