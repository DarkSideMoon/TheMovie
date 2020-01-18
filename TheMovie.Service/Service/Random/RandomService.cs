using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.Service.Client;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Random
{
    public class RandomService : IRandomService
    {
        private readonly IMovieClient _movieClient;

        public RandomService(IMovieClient movieClient)
        {
            _movieClient = movieClient;
        }

        public async Task<Movie> GetRandomMovieAsync(RandomMovieViewModel randomMovieViewModel)
        {
            // From 1 to 4 pages of movies
            int randomPage = new System.Random().Next(1, 4);

            // Random movie per one page
            int randomMovie = new System.Random().Next(1, 20);

            // Get short information about movies
            var movies = new List<ShortMovie>();
                //await _movieClient.GetPopularMoviesByGenreWithYearPageAsync(
                //    getRandomMovieRequest.Genre,
                //    getRandomMovieRequest.Year, randomPage,
                //    getRandomMovieRequest.Language);

            // Get random movie 
            var shortFindedMovie = movies.ElementAtOrDefault(randomMovie);

            // Get full information of movie
            var movie = await _movieClient.GetMovieAsync(new BaseMovieViewModel 
            {
                Id = shortFindedMovie.Id,
                Language = randomMovieViewModel.Language
            });

            throw new NotImplementedException();
        }
    }
}
