using InterfaceLayer.Interfaces;
using PocoLayer.Models;
using RepositoryLayer.Generics;

namespace RepositoryLayer.Specific
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public User GetUser(string userName, string password)
        {
            return
                GetAll().SingleOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
