using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Model.Exceptions;
using TheMovie.Model.Settings;
using TheMovie.Service.Builder;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Client
{
    public class MovieClient : IMovieClient
    {
        private const string ParsedResultsArrayName = "results";
        private const string GenreParsedResultsArrayName = "genres";

        private const string GetMovieUrl = "movie/{0}";
        private const string GetMovieVideosUrl = "movie/{0}/videos";
        private const string SearchMovieUrl = "search/movie";
        private const string GetGenresUrl = "genre/movie/list";

        private readonly HttpClient _httpClient;

        private readonly MovieSettings _movieSettings;

        public MovieClient(HttpClient httpClient, MovieSettings movieSettings)
        {
            _httpClient = httpClient;
            _movieSettings = movieSettings;
        }

        public async Task<Movie> GetMovieAsync(BaseMovieViewModel movieViewModel)
        {
            var getMovieUri = new UrlBuilder(string.Format(GetMovieUrl, movieViewModel.Id))
                .SetApiKey(_movieSettings.ApiKey)
                .SetLanguage(movieViewModel.Language)
                .Build();

            var responseMessage = await _httpClient.GetAsync(getMovieUri);
            if (!responseMessage.IsSuccessStatusCode)
                throw new MovieClientException();

            var response = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Movie>(response);
        }

        public async Task<IEnumerable<ShortMovie>> DiscoverMoviesAsync(DiscoverViewModel discoverViewModel)
        {
            var discoverMovieUri = new UrlBuilder(SearchMovieUrl)
                .SetApiKey(_movieSettings.ApiKey)
                .SetLanguage(discoverViewModel.Language)
                .SetQueryParams(discoverViewModel.DiscoverParams)
                .Build();

            return await ExecuteRequest<IEnumerable<ShortMovie>>(discoverMovieUri, ParsedResultsArrayName);
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync(GenreViewModel genreViewModel)
        {
            var getGenresUri = new UrlBuilder(GetGenresUrl)
                .SetApiKey(_movieSettings.ApiKey)
                .SetLanguage(genreViewModel.Language)
                .Build();

            return await ExecuteRequest<IEnumerable<Genre>>(getGenresUri, GenreParsedResultsArrayName);
        }

        public async Task<IEnumerable<Video>> GetMovieVideosAsync(BaseMovieViewModel movieViewModel)
        {
            var getMovieVideosUri = new UrlBuilder(string.Format(GetMovieVideosUrl, movieViewModel.Id))
                .SetApiKey(_movieSettings.ApiKey)
                .SetLanguage(movieViewModel.Language)
                .Build();

            return await ExecuteRequest<IEnumerable<Video>>(getMovieVideosUri, ParsedResultsArrayName);
        }

        public async Task<IEnumerable<ShortMovie>> SearchAsync(SearchViewModel searchViewModel)
        {
            var searchMovieUri = new UrlBuilder(SearchMovieUrl)
                .SetApiKey(_movieSettings.ApiKey)
                .SetLanguage(searchViewModel.Language)
                .SetQueryParams(new
                {
                    query = searchViewModel.QueryName,
                    include_adult = searchViewModel.IsAdult,
                    region = searchViewModel.Region,
                    year = searchViewModel.Year
                })
                .Build();

            return await ExecuteRequest<IEnumerable<ShortMovie>>(searchMovieUri, ParsedResultsArrayName);
        }

        private async Task<TResult> ExecuteRequest<TResult>(string query, string parsedResultsArrayName)
        {
            var responseMessage = await _httpClient.GetAsync(query);

            if (!responseMessage.IsSuccessStatusCode)
                throw new MovieClientException();

            var response = await responseMessage.Content.ReadAsStringAsync();
            var parsedJsonResponse = JObject.Parse(response);
            return JsonConvert.DeserializeObject<TResult>(parsedJsonResponse[parsedResultsArrayName].ToString());
        }
    }
}
