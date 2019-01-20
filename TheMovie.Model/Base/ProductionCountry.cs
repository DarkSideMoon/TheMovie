using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheMovie.Model.Base
{
    public class ProductionCountry
    {
        [JsonProperty("iso_3166_1")]
        public string ShortName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
