using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Settings
{
    public interface ISettingsService
    {
        Task<IEnumerable<Genre>> GetGenresAsync(GenreViewModel genreViewModel);

        Task<IEnumerable<Language>> GetLanguagesAsync();
    }
}
