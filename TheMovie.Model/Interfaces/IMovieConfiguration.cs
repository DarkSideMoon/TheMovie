using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model.Base;

namespace TheMovie.Model.Interfaces
{
    public interface IMovieConfiguration
    {
        IEnumerable<Genre> GetGenres(string language);

        Task<IEnumerable<Genre>> GetGenresAsync(string language);
    }
}
