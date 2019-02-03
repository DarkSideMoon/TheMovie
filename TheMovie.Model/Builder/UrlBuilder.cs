using System;
using System.Collections.Generic;
using System.Text;
using TheMovie.Model.Util;

namespace TheMovie.Model.Builder
{
    public class UrlBuilder
    {
        private StringBuilder _urlBuilder;

        /// <summary>
        /// Dictionary faster than NameValueCollection 
        /// https://www.dotnetperls.com/namevaluecollection
        /// </summary>
        public Dictionary<string, string> QueryParams { get; set; }

        public UrlBuilder()
        {
            _urlBuilder = new StringBuilder();
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
            QueryParams.Add(name, value);
            return this;
        }

        /// <summary>
        /// Set parameters query api
        /// </summary>
        /// <param name="values"></param>
        public UrlBuilder SetQueryParams(Dictionary<string, string> values)
        {
            foreach (var kv in values)
                QueryParams.Add(kv.Key, kv.Value);

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
                QueryParams.Add(kv.Key, kv.Value.ToString());

            return this;
        }

        /// <summary>
        /// Build all url
        /// </summary>
        /// <returns></returns>
        public string Build() => _urlBuilder.ToString();
    }
}
