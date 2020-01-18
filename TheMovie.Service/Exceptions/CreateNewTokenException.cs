using System;

namespace TheMovie.Service.Exceptions
{
    [Serializable]
    public class CreateNewTokenException : Exception
    {
        public CreateNewTokenException()
        {
        }

        public CreateNewTokenException(string message)
            : base(message)
        {
        }

        public CreateNewTokenException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
