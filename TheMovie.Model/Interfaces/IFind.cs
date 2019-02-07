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

        IEnumerable<Movie> GetPopularMoviesByGenre(int genre, string language);

        Task<IEnumerable<Movie>> GetPopularMoviesByGenreAsync(int genre, string language);

        IEnumerable<Movie> GetPopularMoviesByGenreWithYear(int genre, int year, string language);

        Task<IEnumerable<Movie>> GetPopularMoviesByGenreWithYearAsync(int genre, int year, string language);

        IEnumerable<Movie> GetBestMoviesByYear(int genre, int year, string language);

        Task<IEnumerable<Movie>> GetBestMoviesByYearAsync(int genre, int year, string language);


    }
}
