using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheMovie.Model.Security
{
    public class Token
    {
        [JsonProperty("success")]
        public bool IsSuccess { get; set; }

        [JsonProperty("expires_at")]
        public DateTime ExpireDateTime { get; set; }

        [JsonProperty("request_token")]
        public string RequestToken { get; set; }
    }
}
