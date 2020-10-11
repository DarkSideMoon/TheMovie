using App.Metrics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenTelemetry.Trace;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Model.Common;
using TheMovie.Model.Exceptions;
using TheMovie.Model.Settings;
using TheMovie.Service.Builder;
using TheMovie.Service.Metrics;
using TheMovie.Service.Storage;
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
        private readonly IStorage<Movie> _movieMemoryStorage;
        private readonly MovieSettings _movieSettings;
        private readonly IMetrics _metrics;

        public MovieClient(HttpClient httpClient, 
            IStorage<Movie> movieMemoryStorage,
            MovieSettings movieSettings,
            IMetrics metrics)
        {
            _httpClient = httpClient;
            _movieSettings = movieSettings;
            _movieMemoryStorage = movieMemoryStorage;
            _metrics = metrics;
        }

        public async Task<Movie> GetMovieAsync(BaseMovieViewModel movieViewModel)
        {
            var process = Process.GetCurrentProcess();
            _metrics.Measure.Gauge.SetValue(MetricsRegistry.ServiceMemory, process.WorkingSet64 / 1024.0 / 1024.0);

            using (_metrics.Measure.Timer.Time(MetricsRegistry.MovieRequestTimer))
            {
                //var storageMovie = await _movieMemoryStorage.Get(movieViewModel.Id.ToString());

                //if (storageMovie != null)
                //    return storageMovie;

                var completeUrl = _movieSettings.BaseUrl + GetMovieUrl;
                var getMovieUri = new UrlBuilder(string.Format(completeUrl, movieViewModel.Id))
                    .SetApiKey(_movieSettings.ApiKey)
                    .SetLanguage(movieViewModel.Language)
                    .Build();

                HttpResponseMessage responseMessage = null;
                using (var source = new ActivitySource($"{Constants.Tracing.TraceName}.{nameof(GetMovieAsync)}")
                    .StartActivity("Get moview http request"))
                {
                    responseMessage = await _httpClient.GetAsync(getMovieUri);
                }

                if (!responseMessage.IsSuccessStatusCode)
                    throw new MovieClientException();

                var response = await responseMessage.Content.ReadAsStringAsync();
                var movie = JsonConvert.DeserializeObject<Movie>(response);

                //await _movieMemoryStorage.Set(movie.Id.ToString(), movie);
                return movie;
            }
        }

        public async Task<IEnumerable<ShortMovie>> DiscoverMoviesAsync(DiscoverViewModel discoverViewModel)
        {
            var completeUrl = _movieSettings.BaseUrl + SearchMovieUrl;
            var discoverMovieUri = new UrlBuilder(completeUrl)
                .SetApiKey(_movieSettings.ApiKey)
                .SetLanguage(discoverViewModel.Language)
                .SetQueryParams(discoverViewModel.DiscoverParams)
                .Build();

            return await ExecuteRequest<IEnumerable<ShortMovie>>(discoverMovieUri, ParsedResultsArrayName).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync(GenreViewModel genreViewModel)
        {
            var completeUrl = _movieSettings.BaseUrl + GetGenresUrl;
            var getGenresUri = new UrlBuilder(completeUrl)
                .SetApiKey(_movieSettings.ApiKey)
                .SetLanguage(genreViewModel.Language)
                .Build();

            return await ExecuteRequest<IEnumerable<Genre>>(getGenresUri, GenreParsedResultsArrayName).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Video>> GetMovieVideosAsync(BaseMovieViewModel movieViewModel)
        {
            var completeUrl = _movieSettings.BaseUrl + GetMovieVideosUrl;
            var getMovieVideosUri = new UrlBuilder(string.Format(completeUrl, movieViewModel.Id))
                .SetApiKey(_movieSettings.ApiKey)
                .SetLanguage(movieViewModel.Language)
                .Build();

            return await ExecuteRequest<IEnumerable<Video>>(getMovieVideosUri, ParsedResultsArrayName).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ShortMovie>> SearchAsync(SearchViewModel searchViewModel)
        {
            var completeUrl = _movieSettings.BaseUrl + SearchMovieUrl;
            var searchMovieUri = new UrlBuilder(completeUrl)
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

            return await ExecuteRequest<IEnumerable<ShortMovie>>(searchMovieUri, ParsedResultsArrayName).ConfigureAwait(false);
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
