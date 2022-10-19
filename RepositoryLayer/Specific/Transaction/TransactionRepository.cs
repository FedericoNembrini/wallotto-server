using InterfaceLayer.Interfaces;
using PocoLayer.Models;
using RepositoryLayer.Generics;

namespace RepositoryLayer.Specific
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Transaction> GetUserTransactions(long userId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return
                dbSetEntity
                    .Where(t =>
                        t.UserId == userId
                        && (!fromDate.HasValue || t.Date >= fromDate)
                        && (!toDate.HasValue || t.Date <= toDate)
                    )
                    .AsEnumerable();
        }
    }
}
