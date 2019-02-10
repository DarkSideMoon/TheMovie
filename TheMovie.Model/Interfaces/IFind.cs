using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model.Base;

namespace TheMovie.Model.Interfaces
{
    /// <summary>
    /// Interface to get movies
    /// </summary>
    public interface IFind
    {
        Movie GetMovie(int id, string language);

        Task<Movie> GetMovieAsync(int id, string language);

        IEnumerable<ShortMovie> GetPopularMoviesByGenre(int genre, string language);

        Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreAsync(int genre, string language);

        IEnumerable<ShortMovie> GetPopularMoviesByGenreWithYear(int genre, int year, string language);

        Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreWithYearAsync(int genre, int year, string language);

        IEnumerable<ShortMovie> GetBestMoviesByYear(int genre, int year, string language);

        Task<IEnumerable<ShortMovie>> GetBestMoviesByYearAsync(int genre, int year, string language);
    }
}
