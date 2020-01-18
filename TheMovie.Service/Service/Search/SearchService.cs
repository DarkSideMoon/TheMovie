using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.Service.Client;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Search
{
    public class SearchService : ISearchService
    {
        private readonly IMovieClient _movieClient;

        public SearchService(IMovieClient movieClient)
        {
            _movieClient = movieClient;
        }

        public async Task<IEnumerable<ShortMovie>> SearchAsync(SearchViewModel searchViewModel)
        {
            return await _movieClient.SearchAsync(searchViewModel);
        }
    }
}
