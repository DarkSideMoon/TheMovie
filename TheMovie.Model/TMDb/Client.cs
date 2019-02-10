﻿using System;
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
using TheMovie.Model.ViewModel;

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

        public IEnumerable<ShortMovie> GetPopularMoviesByGenre(int genre, string language) =>
            GetPopularMoviesByGenreAsync(genre, language).Result;

        public async Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreAsync(int genre, string language)
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

            return await ExecuteQuery(query);
        }

        public IEnumerable<ShortMovie> GetPopularMoviesByGenreWithYear(int genre, int year, string language) =>
            GetPopularMoviesByGenreWithYearAsync(genre, year, language).Result;

        public async Task<IEnumerable<ShortMovie>> GetPopularMoviesByGenreWithYearAsync(int genre, int year, string language)
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

            return await ExecuteQuery(query);
        }

        public IEnumerable<ShortMovie> GetBestMoviesByYear(int genre, int year, string language) =>
            GetBestMoviesByYearAsync(genre, year, language).Result;

        public async Task<IEnumerable<ShortMovie>> GetBestMoviesByYearAsync(int genre, int year, string language)
        {
            string query = new UrlBuilder("discover/movie")
                .SetQueryParams(new
                {
                    api_key = _movieSettings.ApiKey,
                    language = language,
                    sort_by = "vote_average.desc",
                    primary_release_year = year,
                    with_genres = genre
                })
                .Build();

            return await ExecuteQuery(query);
        }

        #endregion

        #region Implementation IMovieConfiguration interface

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

        #region Implementation ISearch interface

        public IEnumerable<ShortMovie> Search(SearchViewModel searchViewModel) => SearchAsync(searchViewModel).Result;

        public async Task<IEnumerable<ShortMovie>> SearchAsync(SearchViewModel searchViewModel)
        {
            string query = new UrlBuilder("search/movie")
                .SetQueryParams(new
                {
                    api_key = _movieSettings.ApiKey,
                    language = searchViewModel.Language,
                    query = searchViewModel.QueryName,
                    include_adult = searchViewModel.IsAdult,
                    region = searchViewModel.Region,
                    year = searchViewModel.Year
                })
                .Build();

            return await ExecuteQuery(query);
        }

        #endregion

        #region Helpers method

        private async Task<IEnumerable<ShortMovie>> ExecuteQuery(string query)
        {
            RestRequest request = new RestRequest(query, Method.GET);

            try
            {
                IRestResponse<IEnumerable<ShortMovie>> response = await _restClient.ExecuteTaskAsync<IEnumerable<ShortMovie>>(request);
                var jsonMovies = JObject.Parse(response.Content);
                return JsonConvert.DeserializeObject<IEnumerable<ShortMovie>>(jsonMovies["results"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
