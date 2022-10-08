using InterfaceLayer.Interfaces;
using RepositoryLayer.Specific;

namespace ServiceLayer
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository;

        private readonly IWalletRepository _walletRepository;
        public IWalletRepository WalletRepository => _walletRepository;

        private readonly ICurrencyRepository _currencyRepository;
        public ICurrencyRepository CurrencyRepository => _currencyRepository;

        private readonly ITransactionRepository _transactionRepository;
        public ITransactionRepository TransactionRepository => _transactionRepository;

        private readonly ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;

        private readonly ITransactionTypeRepository _transactionTypeRepository;
        public ITransactionTypeRepository TransactionTypeRepository => _transactionTypeRepository;

        private readonly IFriendRepository _friendRepository;
        public IFriendRepository FriendRepository => _friendRepository;

        public Service(IUnitOfWork unitOfWork, IUserRepository userRepository, IWalletRepository walletRepository, ICurrencyRepository currencyRepository, ITransactionRepository transactionRepository, ICategoryRepository categoryRepository, ITransactionTypeRepository transactionTypeRepository, IFriendRepository friendRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _currencyRepository = currencyRepository;
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
            _transactionTypeRepository = transactionTypeRepository;
            _friendRepository = friendRepository;
        }

        public void Commit()
        {
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
