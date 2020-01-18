using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Random
{
    /// <summary>
    /// Interface for methods to get random movies
    /// </summary>
    public interface IRandomService
    {
        Task<IEnumerable<Movie>> GetRandomMovieAsync(RandomMovieViewModel randomMovieViewModel);
    }
}
