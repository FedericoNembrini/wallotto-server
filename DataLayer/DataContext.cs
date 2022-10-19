using InterfaceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using PocoLayer.Models;

namespace DataLayer
{
    public class DataContext : DbContext, IDbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Wallet> Wallets => Set<Wallet>();
        public DbSet<Currency> Currencies => Set<Currency>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<TransactionType> TransactionTypes => Set<TransactionType>();

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
