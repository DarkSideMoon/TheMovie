using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TheMovie.Model.Builder;
using TheMovie.Model.Interfaces;

namespace TheMovie.Model.Security
{
    public class Auth : IAuth
    {
        /// <summary>
        /// Api key for application
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// Rest client for https queries
        /// </summary>
        private readonly RestClient _restClient;

        public Auth(string apiKey, string baseUrl)
        {
            _apiKey = apiKey;

            _restClient = new RestClient(baseUrl);
        }

        public string CreateToken() => CreateTokenAsync().Result;

        public GuestSession CreateGuestSession() => CreateGuestSessionAsync().Result;

        public bool IsGetPermissionSuccess(string requestToken) => IsGetPermissionSuccessAsync(requestToken).Result;
        public bool DeleteUserSession(string requestToken) => DeleteUserSessionAsync(requestToken).Result;

        public async Task<bool> DeleteUserSessionAsync(string requestToken)
        {
            //string test = new UrlBuilder().AddPath("").SetQueryId("").Build();

            string query = $"authentication/session/new?api_key={_apiKey}" +
                           $"&request_token={requestToken}";

            RestRequest request = new RestRequest(query, Method.DELETE);
            IRestResponse<UserSession> response = await _restClient.ExecuteTaskAsync<UserSession>(request);

            if (!response.IsSuccessful)
                throw new AuthenticationException("Do not have persmission for this operation");

            return true;
        }

        public UserSession CreateUserSession(string requestToken) => CreateUserSessionAsync(requestToken).Result;

        public async Task<string> CreateTokenAsync()
        {
            var request = new RestRequest($"authentication/token/new?api_key={_apiKey}", Method.GET);

            try
            {
                var tokenResponse = await _restClient.ExecuteTaskAsync<Token>(request);
                return tokenResponse.Data.RequestToken;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsGetPermissionSuccessAsync(string requestToken)
        {
            RestClient restClient = new RestClient("https://www.themoviedb.org/");
            RestRequest request = new RestRequest($"authenticate/{requestToken}/allow", Method.GET);

            try
            {
                var response = await restClient.ExecuteTaskAsync(request);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserSession> CreateUserSessionAsync(string requestToken)
        {
            string query = $"authentication/session/new?api_key={_apiKey}" +
                           $"&request_token={requestToken}";

            RestRequest request = new RestRequest(query, Method.POST);
            IRestResponse<UserSession> response = await _restClient.ExecuteTaskAsync<UserSession>(request);

            if (!response.IsSuccessful)
                throw new AuthenticationException("Do not have persmission for this operation");

            return response.Data;
        }

        public async Task<GuestSession> CreateGuestSessionAsync()
        {
            string query = $"authentication/guest_session/new?api_key={_apiKey}";

            RestRequest request = new RestRequest(query, Method.GET);
            IRestResponse<GuestSession> response = await _restClient.ExecuteTaskAsync<GuestSession>(request);

            if (!response.IsSuccessful)
                throw new AuthenticationException("Do not have persmission for this operation");

            return response.Data;
        }
    }
}
