using AutoMapper;
using PocoLayer.Models;
using wallotta_server.Models;

namespace wallotta_server.Mapper
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
