using InterfaceLayer.Interfaces;

#nullable disable

namespace RepositoryLayer.Generics
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal IDbContext dbContext;

        public Repository(IUnitOfWork unitOfWork)
        {
            this.dbContext = unitOfWork.Context;
        }

        public TEntity Find(object[] keyValues)
        {
            return
                dbContext.Set<TEntity>().Find(keyValues);
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void Attach(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return
                dbContext.Set<TEntity>().AsEnumerable();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
