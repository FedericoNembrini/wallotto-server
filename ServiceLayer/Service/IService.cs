using RepositoryLayer.Specific;

namespace ServiceLayer
{
    public interface IService : IDisposable
    {
        IUserRepository UserRepository { get; }

        IWalletRepository WalletRepository { get; }

        ICurrencyRepository CurrencyRepository { get; }

        ITransactionRepository TransactionRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        ITransactionTypeRepository TransactionTypeRepository { get; }

        IFriendRepository FriendRepository { get; }

        void Commit();
    }
}
