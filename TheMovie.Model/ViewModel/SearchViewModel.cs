using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheMovie.Model.ViewModel
{
    public class SearchViewModel
    {
        [JsonProperty("queryName")]
        public string QueryName { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("isAdult")]
        public bool IsAdult { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }
    }
}
