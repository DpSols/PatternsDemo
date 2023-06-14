using Core.Utilities;
using Microsoft.Extensions.Configuration;

namespace SauceDemoTest.Utilities
{
    public static class Configurator
    {
        public static IConfiguration Configuration { get; }

        static Configurator()
        {
            var pathToAppsettings = Path.Combine(AppContext.BaseDirectory, "Resources", "appsettings.json");
            Logger.Instance.Debug($"Getting configurations from {pathToAppsettings}.");
            Configuration = new ConfigurationBuilder()
            .AddJsonFile(pathToAppsettings)
            .Build();
        }
    }
}