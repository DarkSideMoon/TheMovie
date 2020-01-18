using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheMovie.Api.Request;
using TheMovie.Model.Base;
using TheMovie.Model.Common;
using TheMovie.Service.Service.Random;
using TheMovie.Service.ViewModel;

namespace TheMovie.Api.Controllers
{
    /// <summary>
    /// Random controller
    /// </summary>
    [ApiController]
    [Route("random")]
    [Produces(MediaTypeNames.Application.Json)]
    public class RandomController : ControllerBase
    {
        private readonly IRandomService _randomService;

        private readonly IMapper _mapper;

        /// <summary>
        /// The constructor of configurations
        /// </summary>
        /// <param name="randomService"></param>
        /// <param name="mapper"></param>
        public RandomController(IRandomService randomService, IMapper mapper)
        {
            _randomService = randomService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get best movie by the year
        /// </summary>
        /// <param name="getRandomMovieRequest"></param>
        /// <returns>Return random movie</returns>
        /// <response code="200">Return random movie</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> GetRandomMovieAsync([FromQuery] GetRandomMovieRequest getRandomMovieRequest)
        {
            var randomViewModel = _mapper.Map<RandomMovieViewModel>(getRandomMovieRequest);

            var movie = await _randomService.GetRandomMovieAsync(randomViewModel);
            return Ok(movie);
        }
    }
}
