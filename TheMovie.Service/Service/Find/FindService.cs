using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.Service.Client;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Find
{
    public class FindService : IFindService
    {
        private const string PopulatiryDesc = "popularity.desc";
        private const string VoteAverageDesc = "vote_average.desc";

        private readonly IMovieClient _movieClient;

        public FindService(IMovieClient movieClient)
        {
            _movieClient = movieClient;
        }

        public async Task<IEnumerable<ShortMovie>> GetBestMoviesByYearAsync(MovieViewModel movieViewModel)
        {
            var discoverViewModel = new DiscoverViewModel
            {
                Language = movieViewModel.Language,
                DiscoverParams = new
                {
                    sort_by = VoteAverageDesc,
                    primary_release_year = movieViewModel.Year,
                    with_genres = movieViewModel.Genre
                }
            };
            return await _movieClient.DiscoverMoviesAsync(discoverViewModel);
        }

        public async Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreAsync(MovieViewModel movieViewModel)
        {
            var discoverViewModel = new DiscoverViewModel
            {
                Language = movieViewModel.Language,
                DiscoverParams = new
                {
                    sort_by = PopulatiryDesc,
                    with_genres = movieViewModel.Genre
                }
            };
            return await _movieClient.DiscoverMoviesAsync(discoverViewModel);
        }

        public async Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreWithYearAsync(MovieViewModel movieViewModel)
        {
            var discoverViewModel = new DiscoverViewModel
            {
                Language = movieViewModel.Language,
                DiscoverParams = new
                {
                    sort_by = PopulatiryDesc,
                    primary_release_year = movieViewModel.Year,
                    with_genres = movieViewModel.Genre
                }
            };
            return await _movieClient.DiscoverMoviesAsync(discoverViewModel);
        }
    }
}
