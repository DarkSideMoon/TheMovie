using Newtonsoft.Json;

namespace TheMovie.Model.Base
{
    public class Video
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("iso_639_1")]
        public string LanguageSmall { get; set; }

        [JsonProperty("iso_3166_1")]
        public string Language { get; set; }

        private string _key;
        [JsonProperty("key")]
        public string Key
        {
            get
            {
                if (!string.IsNullOrEmpty(_key) && Site == "YouTube")
                    return "https://www.youtube.com/watch?v=" + _key;

                return _key;
            }
            set => _key = value;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
