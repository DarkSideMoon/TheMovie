using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheMovie.Model.Base;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Random
{
    public class RandomService : IRandomService
    {
        public Task<IEnumerable<Movie>> GetRandomMovieAsync(RandomMovieViewModel randomMovieViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
