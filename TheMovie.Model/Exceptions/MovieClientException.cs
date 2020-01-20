using System;

namespace TheMovie.Model.Exceptions
{
    [Serializable]
    public class MovieClientException : Exception
    {
        public MovieClientException()
        {
        }

        public MovieClientException(string message)
            : base(message)
        {
        }

        public MovieClientException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
