using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Interfaces
{
    public interface IMovieSettings
    {
        Task<IEnumerable<Genre>> GetGenresAsync(GenreViewModel genreViewModel);

        Task<IEnumerable<Language>> GetLanguagesAsync();
    }
}
