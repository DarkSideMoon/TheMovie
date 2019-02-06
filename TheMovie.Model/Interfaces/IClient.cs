using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovie.Model.Interfaces
{
    /// <summary>
    /// Aggregation interface of smaller for movie client
    /// </summary>
    public interface IClient : IFind, IMovieConfiguration
    {
    }
}
