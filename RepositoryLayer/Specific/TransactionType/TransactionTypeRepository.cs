using InterfaceLayer.Interfaces;
using PocoLayer.Models;
using RepositoryLayer.Generics;

namespace RepositoryLayer.Specific
{
    public class TransactionTypeRepository : Repository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
