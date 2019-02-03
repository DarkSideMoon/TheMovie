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
    }
}
