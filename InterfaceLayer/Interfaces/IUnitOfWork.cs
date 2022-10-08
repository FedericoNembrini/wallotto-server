namespace InterfaceLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext Context { get; }

        int Save();
    }
}
