using AutoMapper;
using PocoLayer.Models;
using wallotta_server.Models;

namespace wallotta_server.Mapper
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
