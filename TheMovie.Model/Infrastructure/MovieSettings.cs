using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovie.Model.Infrastructure
{
    public class MovieSettings
    {
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
