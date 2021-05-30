using Application.MobileApp.Interfaces.Repositories;
using Infrastructure.MobileApp.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Infrastructure.MobileApp
{
    public static class ServiceRegistrations
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddHttpClient<IUserRepository, UserRepository>().ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, certChain, policyErrors) => true
                };
            });
        }
    }
}
