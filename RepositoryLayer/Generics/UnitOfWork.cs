using InterfaceLayer.Interfaces;

namespace RepositoryLayer.Generics
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        public IDbContext Context => _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Save()
        {
            return
                _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
