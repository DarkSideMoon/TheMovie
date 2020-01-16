using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Interfaces
{
    /// <summary>
    /// Interface to get movies
    /// </summary>
    public interface IFind
    {
        Task<Movie> GetMovieAsync(BaseMovieViewModel movieViewModel);

        Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreAsync(MovieViewModel movieViewModel);

        Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreWithYearAsync(MovieViewModel movieViewModel);

        Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreWithYearPageAsync(MovieViewModel movieViewModel, int pageNumber = 1);

        Task<IEnumerable<ShortMovie>> GetBestMoviesByYearAsync(MovieViewModel movieViewModel);

        Task<IEnumerable<Video>> GetVideosAsync(BaseMovieViewModel movieViewModel);
    }
}
