using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model.Security;
using TheMovie.Model.Settings;
using TheMovie.Model.Exceptions;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Auth
{
    public class AuthService : IAuthService
    {
        private const string NewTokenUrl = "authentication/token/new?api_key={0}";
        private const string GuestSessionUrl = "authentication/guest_session/new?api_key={0}";
        private const string UserSessionUrl = "authentication/session/new?api_key={0}";

        private const string AuthenticationErrorMessage = "Do not have persmission for this operation";
        private const string CreateNewTokenErrorMessage = "Do not have persmission for this operation";

        private readonly MovieSettings _movieSettings;

        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient, MovieSettings movieSettings)
        {
            _httpClient = httpClient;
            _movieSettings = movieSettings;
        }

        public async Task<GuestSession> CreateGuestSessionAsync()
        {
            var requestUri = CreateRequestUri(GuestSessionUrl);

            var responseMessage = await _httpClient.GetAsync(requestUri);
            if (!responseMessage.IsSuccessStatusCode)
                throw new AuthenticationException(AuthenticationErrorMessage);

            var tokenResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GuestSession>(tokenResponse);
        }

        public async Task<Token> CreateTokenAsync()
        {
            var requestUri = CreateRequestUri(NewTokenUrl);

            var responseMessage = await _httpClient.GetAsync(requestUri);
            if (!responseMessage.IsSuccessStatusCode)
                throw new CreateNewTokenException(CreateNewTokenErrorMessage);

            var tokenResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Token>(tokenResponse);
        }

        public async Task<UserSession> CreateUserSessionAsync(AuthViewModel authViewModel)
        {
            var requestUri = CreateRequestUri(UserSessionUrl);

            var requestToken = JsonConvert.SerializeObject(authViewModel);
            var responseMessage = 
                await _httpClient.PostAsync(requestUri, new StringContent(requestToken, Encoding.UTF8, MediaTypeNames.Application.Json));

            if (!responseMessage.IsSuccessStatusCode)
                throw new AuthenticationException(AuthenticationErrorMessage);

            var tokenResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserSession>(tokenResponse);
        }

        public async Task<bool> DeleteUserSessionAsync(SessionViewModel sessionViewModel)
        {
            var requestUri = CreateRequestUri(UserSessionUrl);
            var session = JsonConvert.SerializeObject(sessionViewModel);

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = requestUri,
                Content = new StringContent(session, Encoding.UTF8, MediaTypeNames.Application.Json)
            };
            var responseMessage = await _httpClient.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new AuthenticationException(AuthenticationErrorMessage);

            var tokenResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserSession>(tokenResponse).IsSuccess;
        }

        public Task<bool> IsGetPermissionSuccessAsync(AuthViewModel authViewModel)
        {
            throw new NotImplementedException();
        }

        private Uri CreateRequestUri(string url)
        {
            return new Uri(string.Format(url, _movieSettings.ApiKey));
        }
    }
}
