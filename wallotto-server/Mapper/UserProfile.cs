using AutoMapper;
using PocoLayer.Models;
using wallotto_server.Models;

namespace wallotto_server.Mapper
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
