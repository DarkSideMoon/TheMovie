using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheMovie.Model.Base
{
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("adult")]
        public bool IsAdult { get; set; }

        [JsonProperty("budget")]
        public double Budget { get; set; }

        [JsonProperty("revenue")]
        public double Revenue { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("tagline")]
        public string TagLine { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("homepage")]
        public string HomeUrl { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        private string _backgroundImage;
        [JsonProperty("backdrop_path")]
        public string BackgroundImage
        {
            get
            {
                if (_backgroundImage != null && !_backgroundImage.Contains("image.tmdb.org"))
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
                if (_posterImage != null && !_posterImage.Contains("image.tmdb.org"))
                    return "https://image.tmdb.org/t/p/w780/" + _posterImage;

                return _posterImage;
            }
            set => _posterImage = value;
        }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDateTime { get; set; }

        [JsonProperty("status")]
        public string State { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; }
    }
}
