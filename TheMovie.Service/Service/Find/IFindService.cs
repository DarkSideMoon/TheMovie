using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Find
{
    public interface IFindService
    {
        Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreAsync(MovieViewModel movieViewModel);

        Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreWithYearAsync(MovieViewModel movieViewModel);

        Task<IEnumerable<ShortMovie>> GetBestMoviesByYearAsync(MovieViewModel movieViewModel);
    }
}
