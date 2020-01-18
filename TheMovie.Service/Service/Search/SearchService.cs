using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Model.ViewModel;

namespace TheMovie.Service.Service.Search
{
    public class SearchService : ISearchService
    {
        public Task<IEnumerable<ShortMovie>> SearchAsync(SearchViewModel searchViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
