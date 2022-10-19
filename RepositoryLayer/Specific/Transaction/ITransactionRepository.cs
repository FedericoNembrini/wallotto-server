using InterfaceLayer.Interfaces;
using PocoLayer.Models;

namespace RepositoryLayer.Specific
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetUserTransactions(long userId, DateTime? fromDate = null, DateTime? toDate = null);
    }
}
