using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheMovie.Model.ViewModel
{
    public class ErrorViewModel
    {
        [JsonProperty("info")]
        public string Information { get; set; } = "Sorry, an error occurred. Try again later. Thank you for using our service";

        [JsonProperty("actionName")]
        public string ActionName { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("trace")]
        public string StackTrace { get; set; }


        public string BuildJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
