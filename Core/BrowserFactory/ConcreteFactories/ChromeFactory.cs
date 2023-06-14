using Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Core.BrowserFactory.ConcreteFactories;

internal class ChromeFactory : BrowserFactory
{
    protected override WebDriver WebDriver
    {
        get
        {
            string version = VersionResolveStrategy.MatchingBrowser;
            Logger.Instance.Debug($"ChromeFactory overriding the browser. Version is set to {version}");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), version);
            
            if (BrowserOptions.Length != 0)
            {
                var settings = new ChromeOptions();
                settings.AddArguments(BrowserOptions);
                Logger.Instance.Debug($"ChromeFactory setting options {settings}");
                return new ChromeDriver(settings);
            }
            
            Logger.Instance.Debug("ChromeFactory setting driver without options");
            return new ChromeDriver();
        }
    }
}