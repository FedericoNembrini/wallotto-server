using AutoMapper;
using PocoLayer.Models;
using wallotta_server.Models;

namespace wallotta_server.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
                .ReverseMap();
        }
    }
}
