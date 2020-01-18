using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using TheMovie.Api.Request;
using TheMovie.Model.Base;
using TheMovie.Model.Common;
using TheMovie.Service.Service.Search;
using TheMovie.Service.ViewModel;

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
        private readonly ISearchService _searchService;

        private readonly IMapper _mapper;

        /// <summary>
        /// Search constructor
        /// </summary>
        /// <param name="searchService"></param>
        /// <param name="mapper"></param>
        public SearchController(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        /// <summary>
        /// Search movies
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns>Return find movies</returns>
        /// <response code="200">Return find movie</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(typeof(List<ShortMovie>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> Search([FromBody] SearchRequest searchRequest)
        {
            var searchViewModel = _mapper.Map<SearchViewModel>(searchRequest);

            var movies = await _searchService.SearchAsync(searchViewModel);
            return Ok(movies);
        }
    }
}
