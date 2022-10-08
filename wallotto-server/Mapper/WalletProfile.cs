using AutoMapper;
using PocoLayer.Models;
using wallotta_server.Models;

namespace wallotta_server.Mapper
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletDTO, Wallet>()
                .ReverseMap();
        }
    }
}
