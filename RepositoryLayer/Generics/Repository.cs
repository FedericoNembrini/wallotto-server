using InterfaceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositoryLayer.Generics
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal IDbContext dbContext;

        internal DbSet<TEntity> dbSetEntity => dbContext.Set<TEntity>();

        public Repository(IUnitOfWork unitOfWork)
        {
            this.dbContext = unitOfWork.Context;
        }

        public TEntity Find(object[] keyValues)
        {
            return
                dbContext.Set<TEntity>().Find(keyValues);
        }

        public Task<TEntity> FindAsync(object[] keyValues)
        {
            return dbContext.Set<TEntity>().FindAsync(keyValues).AsTask();
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

        public IEnumerable<TEntity> GetAll(bool trackChanges = true)
        {
            return
                trackChanges ? dbContext.Set<TEntity>().AsEnumerable() : dbContext.Set<TEntity>().AsNoTracking().AsEnumerable();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
