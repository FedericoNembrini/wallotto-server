using DataLayer;
using InterfaceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Generics;
using RepositoryLayer.Specific;

namespace ServiceLayer
{
    public class Bootstrapper
    {
        public static void RegisterTypes(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DataContext>(options => options.UseSqlite(connectionString), ServiceLifetime.Scoped);

            serviceCollection.AddScoped<IDbContext>(provider => provider.GetService<DataContext>());

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            serviceCollection.AddScoped<IService, Service>();

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IWalletRepository, WalletRepository>();

            // Poco ?
        }
    }
}
