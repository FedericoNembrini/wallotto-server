using DataLayer;
using InterfaceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Generics;

namespace ServiceLayer
{
    public class Bootstrapper
    {
        public static void RegisterTypes(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<DataContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            serviceCollection.AddScoped<IDbContext>(provider => provider.GetService<DataContext>());

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            serviceCollection.AddScoped<IService, Service>();

            List<Type> repositoryTypeList =
                AppDomain.CurrentDomain.GetAssemblies()
                    .First(a => a.GetName().Name.Contains("Repository"))
                    .GetTypes()
                    .Where(t => t.IsClass && t.Name.EndsWith("Repository") && t.FullName.StartsWith("RepositoryLayer.Specific"))
                    .ToList();

            foreach (Type repositoryType in repositoryTypeList)
                serviceCollection.AddScoped(
                    repositoryType.GetInterfaces().Single(i => i.FullName.StartsWith("RepositoryLayer.Specific")),
                    repositoryType
                );

            //serviceCollection.AddScoped<IUserRepository, UserRepository>();
            //serviceCollection.AddScoped<IWalletRepository, WalletRepository>();
            //serviceCollection.AddScoped<ICurrencyRepository, CurrencyRepository>();
            //serviceCollection.AddScoped<ITransactionRepository, TransactionRepository>();
            //serviceCollection.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            //serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            //serviceCollection.AddScoped<IFriendRepository, FriendRepository>();
        }
    }
}
