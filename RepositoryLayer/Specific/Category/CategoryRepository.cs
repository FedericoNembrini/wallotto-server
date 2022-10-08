using InterfaceLayer.Interfaces;
using PocoLayer.Models;
using RepositoryLayer.Generics;

namespace RepositoryLayer.Specific
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
