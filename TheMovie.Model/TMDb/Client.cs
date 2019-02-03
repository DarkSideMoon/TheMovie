using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TheMovie.Model.Base;
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
        #endregion
    }
}
