using System.Linq;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.Service.Client;
using TheMovie.Service.Service.Find;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Random
{
    public class RandomService : IRandomService
    {
        private readonly IFindService _findService;
        private readonly IMovieClient _movieClient;

        public RandomService(IMovieClient movieClient, IFindService findService)
        {
            _movieClient = movieClient;
            _findService = findService;
        }

        public async Task<Movie> GetRandomMovieAsync(RandomMovieViewModel randomMovieViewModel)
        {
            // Random movie per one page
            int randomMovie = new System.Random().Next(1, 20);

            // Get short information about movies
            var movies = await _findService.GetPopularMoviesByGenreWithYearAsync(new MovieViewModel
            {
                Genre = randomMovieViewModel.Genre,
                Language = randomMovieViewModel.Language,
                Year = randomMovieViewModel.Year
            });

            // Get random movie 
            var shortFindedMovie = movies.ElementAtOrDefault(randomMovie);

            // Get full information of movie
            return await _movieClient.GetMovieAsync(new BaseMovieViewModel 
            {
                Id = shortFindedMovie.Id,
                Language = randomMovieViewModel.Language
            });
        }
    }
}
