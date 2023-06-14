using Core.BrowserFactory;
using Core.Utilities;
using Microsoft.Extensions.Configuration;
using SauceDemoTest.Utilities;

namespace SauceDemoTest.AppConfigurations;

public static class AppConfiguration
{

    public static string[] ChromeOptions
    {
        get
        {
            string[] chromeOptions = Configurator.Configuration.GetSection("ChromeOptions").Get<string[]>();
            Logger.Instance.Debug($"Applying chrome options: {string.Join(", ", chromeOptions)}");
            return chromeOptions;
        }
    }

    public static BrowserNames BrowserName
    {
        get
        {
            var browserName = Configurator.Configuration.GetValue<string>("BrowserName");
            Logger.Instance.Debug($"Using {browserName} browser.");
            return Enum.Parse<BrowserNames>(browserName);
        }
    }

    public static string BaseUrl
    {
        get
        {
            var baseUrl = Configurator.Configuration.GetValue<string>("Url");
            Logger.Instance.Debug($"BaseUrl is {baseUrl}");
            return baseUrl;
        }
    }
}