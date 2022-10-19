using InterfaceLayer.Interfaces;
using PocoLayer.Models;

namespace RepositoryLayer.Specific
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(string userName, string password);
    }
}
