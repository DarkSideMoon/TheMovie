using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheMovie.Model.Builder
{
    public class UrlBuilder
    {
        private StringBuilder _urlBuilder;

        /// <summary>
        /// Dictionary faster than NameValueCollection 
        /// https://www.dotnetperls.com/namevaluecollection
        /// </summary>
        private Dictionary<string, string> _queryParams = new Dictionary<string, string>();

        public UrlBuilder()
        {
            _urlBuilder = new StringBuilder();
        }

        public UrlBuilder(string baseUrl)
        {
            _urlBuilder = new StringBuilder();
            _urlBuilder.Append(baseUrl);
        }

        /// <summary>
        /// Add endpoint of api
        /// </summary>
        /// <param name="path"></param>
        public UrlBuilder AddPath(string path)
        {
            _urlBuilder.Append(path);
            return this;
        }

        /// <summary>
        /// Add several endpoints of api
        /// </summary>
        /// <param name="pathes"></param>
        public UrlBuilder AddPath(IEnumerable<string> pathes)
        {
            _urlBuilder.Append(String.Join("/", pathes));
            return this;
        }

        public UrlBuilder SetQueryId(string value)
        {
            _urlBuilder.Append("/" + value);
            return this;
        }

        /// <summary>
        /// Set one param
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public UrlBuilder SetQueryParam(string name, string value)
        {
            _queryParams.Add(name, value);
            return this;
        }

        /// <summary>
        /// Set parameters query api
        /// </summary>
        /// <param name="values"></param>
        public UrlBuilder SetQueryParams(Dictionary<string, string> values)
        {
            foreach (var kv in values)
                _queryParams.Add(kv.Key, kv.Value);

            return this;
        }

        /// <summary>
        /// Set parameters query api from object
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public UrlBuilder SetQueryParams(object values)
        {
            return this;
        }

        /// <summary>
        /// Build all url
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            if (_queryParams.Any())
            {
                _urlBuilder.Append("?");
                foreach (var queryParam in _queryParams)
                {
                    string query = $"{queryParam.Key}={queryParam.Value}";

                    if (_queryParams.LastOrDefault().Key != queryParam.Key)
                        query += "&";

                    _urlBuilder.Append(query);
                }
            }

            return _urlBuilder.Replace(" ", "").ToString();
        } 
    }
}
