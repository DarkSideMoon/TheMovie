using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using TheMovie.Api.Filters;
using TheMovie.Model.Base;
using TheMovie.Model.Interfaces;
using TheMovie.Model.ViewModel;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheMovie.Api.Controllers
{
    /// <summary>
    /// Search controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        /// <summary>
        /// Client for movie service
        /// </summary>
        private readonly IClient _client;

        /// <summary>
        /// Search constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        public SearchController(IServiceProvider serviceProvider)
        {
            _client = serviceProvider.GetService<IClient>();
        }

        /// <summary>
        /// Search movies
        /// </summary>
        /// <param name="searchViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("search")]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(List<ShortMovie>), 200)]
        public async Task<IActionResult> Search([FromBody] SearchViewModel searchViewModel)
        {
            var movies = await _client.SearchAsync(searchViewModel);
            return Ok(movies);
        }
    }
}
