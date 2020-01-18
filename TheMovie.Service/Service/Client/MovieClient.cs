using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Client
{
    public class MovieClient : IMovieClient
    {
        public Task<IEnumerable<ShortMovie>> DiscoverMoviesAsync(MovieViewModel movieViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Genre>> GetGenresAsync(GenreViewModel genreViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieAsync(BaseMovieViewModel movieViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Video>> GetVideosAsync(BaseMovieViewModel movieViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShortMovie>> SearchAsync(SearchViewModel searchViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
