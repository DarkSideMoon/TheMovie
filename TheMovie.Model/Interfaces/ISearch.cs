using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Model.ViewModel;

namespace TheMovie.Model.Interfaces
{
    /// <summary>
    /// Interface for methods to search movies by different parameters
    /// </summary>
    public interface ISearch
    {
        IEnumerable<ShortMovie> Search(SearchViewModel searchViewModel);

        Task<IEnumerable<ShortMovie>> SearchAsync(SearchViewModel searchViewModel);
    }
}
