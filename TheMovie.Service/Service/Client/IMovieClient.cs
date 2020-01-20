using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Client
{
    public interface IMovieClient
    {
        Task<Movie> GetMovieAsync(BaseMovieViewModel movieViewModel);

        Task<IEnumerable<ShortMovie>> DiscoverMoviesAsync(DiscoverViewModel discoverViewModel);

        Task<IEnumerable<ShortMovie>> SearchAsync(SearchViewModel searchViewModel);

        Task<IEnumerable<Video>> GetMovieVideosAsync(BaseMovieViewModel movieViewModel);

        Task<IEnumerable<Genre>> GetGenresAsync(GenreViewModel genreViewModel);
    }
}
