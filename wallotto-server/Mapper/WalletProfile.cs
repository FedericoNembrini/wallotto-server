using AutoMapper;
using PocoLayer.Models;
using wallotto_server.Models;

namespace wallotto_server.Mapper
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
