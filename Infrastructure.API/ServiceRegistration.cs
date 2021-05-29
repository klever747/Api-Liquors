using Application.API.Interfaces.Repositories;
using Application.API.Repositories;
using Application.API.Services;
using Infrastructure.API.Contexts;
using Infrastructure.API.Interfaces;
using Infrastructure.API.Repositories;
using Infrastructure.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.API
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(@"Server=DESKTOP-RMUFT67\SQLEXPRESS; Database=AtenasLiquorsDB; Trusted_Connection=True;",
                options => options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProveedorRepository, ProveedorRepository>();
            services.AddTransient<ISalesRepository, SalesRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<ISecurityRepository, SecurityRepository>();
            services.AddSingleton<IPasswordHasher, PasswordService>();
        }
    }
}
