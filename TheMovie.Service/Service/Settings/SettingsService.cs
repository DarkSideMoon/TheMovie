using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.Service.Client;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly IMovieClient _movieClient;

        public SettingsService(IMovieClient movieClient)
        {
            _movieClient = movieClient;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync(GenreViewModel genreViewModel)
        {
            return await _movieClient.GetGenresAsync(genreViewModel);
        }

        public IEnumerable<Language> GetLanguages()
        {
            return new List<Language>
            {
                new Language(LanguageName.English, LanguageType.English, string.Empty),
                new Language(LanguageName.Ukrainian, LanguageType.Ukrainian, string.Empty),
                new Language(LanguageName.Italian, LanguageType.Italian, string.Empty),
                new Language(LanguageName.French, LanguageType.French, string.Empty),
                new Language(LanguageName.German, LanguageType.German, string.Empty),
                new Language(LanguageName.Spanish, LanguageType.Spanish, string.Empty),
                new Language(LanguageName.Russian, LanguageType.Russian, string.Empty)
            };
        }
    }
}
