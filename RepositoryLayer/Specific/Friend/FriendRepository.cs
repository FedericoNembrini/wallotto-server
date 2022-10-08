using InterfaceLayer.Interfaces;
using PocoLayer.Models;
using RepositoryLayer.Generics;

namespace RepositoryLayer.Specific
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        public FriendRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
