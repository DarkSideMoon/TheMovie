using Newtonsoft.Json;

namespace TheMovie.Service.ViewModel
{
    public class AuthViewModel
    {
        [JsonProperty("request_token")]
        public string RequestToken { get; set; }
    }
}
