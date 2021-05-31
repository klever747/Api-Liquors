using Infrastructure.MobileApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using Xamarin.Essentials;

namespace MobileLiquorApp
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Init()
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configuration => configuration.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" }))
                .ConfigureServices(services => services.AddInfrastructureLayer()).Build();

            ServiceProvider = host.Services;
        }
    }
}
