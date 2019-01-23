using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheMovie.Model.Security
{
    public class UserSession
    {
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }
    }
}
