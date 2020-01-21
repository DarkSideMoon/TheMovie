using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheMovie.Model.Common;

namespace TheMovie.Service.Builder
{
    public class UrlBuilder
    {
        private readonly StringBuilder _urlBuilder;

        /// <summary>
        /// Dictionary faster than NameValueCollection 
        /// https://www.dotnetperls.com/namevaluecollection
        /// </summary>
        private readonly Dictionary<string, string> _queryParams = new Dictionary<string, string>();

        public UrlBuilder(string baseUrl)
        {
            _urlBuilder = new StringBuilder();
            _urlBuilder.Append(baseUrl);
        }

        public UrlBuilder SetApiKey(string apiKey)
        {
            _queryParams.Add(Constants.Movie.ApiKey, apiKey);
            return this;
        }

        public UrlBuilder SetLanguage(string language)
        {
            _queryParams.Add(Constants.Movie.Language, language);
            return this;
        }

        /// <summary>
        /// Set parameters query api from object
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public UrlBuilder SetQueryParams(object values)
        {
            foreach (var kv in values.ToKeyValuePairs())
                _queryParams.Add(kv.Key, kv.Value.ToString());

            return this;
        }

        /// <summary>
        /// Build all url
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            _urlBuilder.Append("?");
            foreach (var queryParam in _queryParams)
            {
                string query = $"{queryParam.Key}={queryParam.Value}";

                if (_queryParams.LastOrDefault().Key != queryParam.Key)
                    query += "&";

                _urlBuilder.Append(query);
            }

            return _urlBuilder.Replace(" ", "").ToString();
        }
    }
}
