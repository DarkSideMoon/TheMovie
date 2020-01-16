using AutoMapper;
using TheMovie.Api.Request;
using TheMovie.Model.ViewModel;

namespace TheMovie.Api.Mapping
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<SearchRequest, SearchViewModel>();
        }
    }
}
