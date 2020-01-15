using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Model.Common;
using TheMovie.Model.Interfaces;
using TheMovie.Model.ViewModel;

namespace TheMovie.Api.Controllers
{
    /// <summary>
    /// Search controller
    /// </summary>
    [ApiController]
    [Route("search")]
    [Produces(MediaTypeNames.Application.Json)]
    public class SearchController : ControllerBase
    {
        /// <summary>
        /// Client for movie service
        /// </summary>
        private readonly IClient _client;

        /// <summary>
        /// Search constructor
        /// </summary>
        /// <param name="client"></param>
        public SearchController(IClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Search movies
        /// </summary>
        /// <param name="searchViewModel"></param>
        /// <returns>Return find movies</returns>
        /// <response code="200">Return find movie</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(typeof(List<ShortMovie>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> Search([FromBody] SearchViewModel searchViewModel)
        {
            var movies = await _client.SearchAsync(searchViewModel);
            return Ok(movies);
        }
    }
}
