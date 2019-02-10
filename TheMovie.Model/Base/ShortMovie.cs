using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheMovie.Model.Base
{
    public class ShortMovie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        private string _backgroundImage;
        [JsonProperty("backdrop_path")]
        public string BackgroundImage
        {
            get
            {
                if (!string.IsNullOrEmpty(_backgroundImage) && !_backgroundImage.Contains("image.tmdb.org"))
                    return "https://image.tmdb.org/t/p/w780/" + _backgroundImage;

                return _backgroundImage;
            }
            set => _backgroundImage = value;
        }

        private string _posterImage;
        [JsonProperty("poster_path")]
        public string PosterImage
        {
            get
            {
                if (!string.IsNullOrEmpty(_posterImage) && !_posterImage.Contains("image.tmdb.org"))
                    return "https://image.tmdb.org/t/p/w780/" + _posterImage;

                return _posterImage;
            }
            set => _posterImage = value;
        }

        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("adult")]
        public bool IsAdult { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDateTime { get; set; }

        public ShortMovie()
        {
            Genres = new List<Genre>();
        }
    }
}
