using AutoMapper;
using PocoLayer.Models;
using wallotto_server.Models;

namespace wallotto_server.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, Category>()
                .ReverseMap();
        }
    }
}
