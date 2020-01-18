using Newtonsoft.Json;

namespace TheMovie.Service.ViewModel
{
    public class SessionViewModel
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
    }
}
