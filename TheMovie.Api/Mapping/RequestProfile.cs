using AutoMapper;
using TheMovie.Api.Request;
using TheMovie.Model.ViewModel;

namespace TheMovie.Api.Mapping
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<MovieRequest, Service.ViewModel.MovieViewModel>();

            CreateMap<SearchRequest, SearchViewModel>();

            CreateMap<GetGenresRequest, Service.ViewModel.GenreViewModel>();

            CreateMap<GetRandomMovieRequest, Service.ViewModel.RandomMovieViewModel>()
                .IncludeBase<MovieRequest, Service.ViewModel.MovieViewModel>();
        }
    }
}
