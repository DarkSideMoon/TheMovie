using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheMovie.Model.Security
{
    public class GuestSession
    {
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        [JsonProperty("guest_session_id")]
        public string SessionId { get; set; }

        [JsonProperty("expires_at")]
        public DateTime ExpireDateTime { get; set; }
    }
}
