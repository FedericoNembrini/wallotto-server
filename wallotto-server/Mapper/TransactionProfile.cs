using AutoMapper;
using PocoLayer.Models;
using wallotto_server.Models;

namespace wallotto_server.Mapper
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionDTO, Transaction>()
                .ReverseMap();
        }
    }
}
