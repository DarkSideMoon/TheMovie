using Newtonsoft.Json;

namespace TheMovie.Model.Base
{
    public class Language
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        public Language(string name, string code, string logo)
        {
            Name = name;
            Code = code;
            Logo = logo;
        }
    }
}
