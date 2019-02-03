using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TheMovie.Model.Util
{
    public static class CommonExtensions
    {
        public static IEnumerable<KeyValuePair<string, object>> ToKeyValuePairs(this object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var inputObject = obj.ToString();
            var arrayObjects = inputObject
                .Replace("{", "")
                .Replace("}", "")
                .Trim()
                .Split(',');

            foreach (var str in arrayObjects)
            {
                var keyValue = str.Trim();
                var keyValueArray = keyValue.Split('=');

                var key = keyValueArray[0];
                var value = keyValueArray[1];

                yield return new KeyValuePair<string, object>(key, value);
            }
        }
    }
}
