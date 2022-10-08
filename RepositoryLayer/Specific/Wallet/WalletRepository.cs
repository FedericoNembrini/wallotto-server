using InterfaceLayer.Interfaces;
using PocoLayer.Models;
using RepositoryLayer.Generics;

namespace RepositoryLayer.Specific
{
    public class WalletRepository : Repository<Wallet>, IWalletRepository
    {
        public WalletRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
