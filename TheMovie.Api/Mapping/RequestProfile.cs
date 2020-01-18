using AutoMapper;
using TheMovie.Api.Request;
using TheMovie.Service.ViewModel;

namespace TheMovie.Api.Mapping
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<MovieRequest, MovieViewModel>();

            CreateMap<SearchRequest, SearchViewModel>();

            CreateMap<GetGenresRequest, GenreViewModel>();

            CreateMap<GetRandomMovieRequest, RandomMovieViewModel>()
                .IncludeBase<MovieRequest, MovieViewModel>();
        }
    }
}
