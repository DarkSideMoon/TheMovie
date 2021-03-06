﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TheMovie.Model.Base
{
    public class Movie
    {
        private readonly static string ImageTheMovieDb = "image.tmdb.org";

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
                if (!string.IsNullOrEmpty(_backgroundImage) && !_backgroundImage.Contains(ImageTheMovieDb))
                {
                    return "https://image.tmdb.org/t/p/w780/" + _backgroundImage;
                }

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
                if (!string.IsNullOrEmpty(_posterImage) && !_posterImage.Contains(ImageTheMovieDb))
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
        public IEnumerable<Genre> Genres { get; set; }

        [JsonProperty("production_companies")]
        public IEnumerable<ProductionCompany> ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public IEnumerable<ProductionCountry> ProductionCountries { get; set; }

        [JsonProperty("videos")]
        public IEnumerable<Video> Videos { get; set; }
    }
}
