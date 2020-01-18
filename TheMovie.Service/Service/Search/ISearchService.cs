using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Model.ViewModel;

namespace TheMovie.Service.Service.Search
{
    /// <summary>
    /// Interface for methods to search movies by different parameters
    /// </summary>
    public interface ISearchService
    {
        Task<IEnumerable<ShortMovie>> SearchAsync(SearchViewModel searchViewModel);
    }
}
