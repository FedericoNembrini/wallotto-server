namespace InterfaceLayer.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Find(object[] keyValues);

        void Add(TEntity entity);

        void Attach(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
    }
}
