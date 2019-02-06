using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TheMovie.Model.Base;
using TheMovie.Model.Builder;
using TheMovie.Model.Infrastructure;
using TheMovie.Model.Interfaces;

namespace TheMovie.Model.TMDb
{
    /// <summary>
    /// Implementation interface of IClient for https://themoviedb.org service
    /// </summary>
    public class Client : IClient
    {
        private readonly MovieSettings _movieSettings;

        private readonly RestClient _restClient;

        public Client(MovieSettings movieSettings)
        {
            _movieSettings = movieSettings;

            _restClient = new RestClient(_movieSettings.BaseUrl);
        }

        #region Implementation IFind interface

        public Movie GetMovie(int id, string language) => GetMovieAsync(id, language).Result;

        public async Task<Movie> GetMovieAsync(int id, string language)
        {
            string query = $"movie/{id}?api_key={_movieSettings.ApiKey}&language={language}";
            RestRequest request = new RestRequest(query, Method.GET);

            try
            {
                IRestResponse<Movie> response = await _restClient.ExecuteTaskAsync<Movie>(request);
                return JsonConvert.DeserializeObject<Movie>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Movie> GetPopularMoviesByGenre(int genre, string language) =>
            GetPopularMoviesByGenreAsync(genre, language).Result;

        public async Task<IEnumerable<Movie>> GetPopularMoviesByGenreAsync(int genre, string language)
        {
            string query = new UrlBuilder("discover/movie")
                .SetQueryParams(new
                {
                    api_key = _movieSettings.ApiKey,
                    language = language,
                    sort_by = "popularity.desc",
                    with_genres = genre
                })
                .Build();

            RestRequest request = new RestRequest(query, Method.GET);

            try
            {
                IRestResponse<IEnumerable<Movie>> response = await _restClient.ExecuteTaskAsync<IEnumerable<Movie>>(request);
                var jsonMovies = JObject.Parse(response.Content);
                return JsonConvert.DeserializeObject<IEnumerable<Movie>>(jsonMovies["results"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Movie> GetPopularMoviesByGenreWithYear(int genre, int year, string language) =>
            GetPopularMoviesByGenreWithYearAsync(genre, year, language).Result;

        public async Task<IEnumerable<Movie>> GetPopularMoviesByGenreWithYearAsync(int genre, int year, string language)
        {
            string query = new UrlBuilder("discover/movie")
                .SetQueryParams(new
                {
                    api_key = _movieSettings.ApiKey,
                    language = language,
                    sort_by = "popularity.desc",
                    primary_release_year = year,
                    with_genres = genre
                })
                .Build();

            RestRequest request = new RestRequest(query, Method.GET);

            try
            {
                IRestResponse<IEnumerable<Movie>> response = await _restClient.ExecuteTaskAsync<IEnumerable<Movie>>(request);
                var jsonMovies = JObject.Parse(response.Content);
                return JsonConvert.DeserializeObject<IEnumerable<Movie>>(jsonMovies["results"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Implementation IFind interface

        public IEnumerable<Genre> GetGenres(string language) => GetGenresAsync(language).Result;

        public async Task<IEnumerable<Genre>> GetGenresAsync(string language)
        {
            string query = new UrlBuilder()
                .AddPath(new[] { "genre", "movie", "list" })
                .SetQueryParams(new
                {
                    api_key = _movieSettings.ApiKey,
                    language = language
                })
                .Build();

            RestRequest request = new RestRequest(query, Method.GET);

            try
            {
                IRestResponse<IEnumerable<Genre>> response = await _restClient.ExecuteTaskAsync<IEnumerable<Genre>>(request);
                var jsonGenres = JObject.Parse(response.Content);
                return JsonConvert.DeserializeObject<IEnumerable<Genre>>(jsonGenres["genres"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
