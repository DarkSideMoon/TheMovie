using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Interfaces
{
    /// <summary>
    /// Interface for methods to get random movies
    /// </summary>
    public interface IRandom
    {
        Task<IEnumerable<Movie>> RandomAsync(MovieViewModel movieViewModel);
    }
}
