using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Model.ViewModel;

namespace TheMovie.Model.Interfaces
{
    /// <summary>
    /// Interface for methods to get random movies
    /// </summary>
    public interface IRandom
    {
        IEnumerable<Movie> Search(SearchViewModel searchViewModel);

        Task<IEnumerable<Movie>> SearchAsync(SearchViewModel searchViewModel);
    }
}
