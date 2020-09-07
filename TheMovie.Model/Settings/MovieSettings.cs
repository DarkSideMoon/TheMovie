namespace TheMovie.Model.Settings
{
    public class MovieSettings
    {
        public MovieSettings(string apiKey, string baseUrl)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Key of application TMDb
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Base url of api
        /// </summary>
        public string BaseUrl { get; set; }

    }
}
