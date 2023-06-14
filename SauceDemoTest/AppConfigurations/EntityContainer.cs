using Core.BrowserFactory;
using Core.SeleniumWrapper.ElementsFactory;

namespace SauceDemoTest.AppConfigurations;

public static class EntityContainer
{
    private static readonly Func<IBrowser> s_browserFactory = () => new BrowserService(AppConfiguration.ChromeOptions, AppConfiguration.BrowserName).Browser;
    private static readonly Func<ElementFactory> s_factoryFactory = () => new ElementFactory(Browser.WebDriver);

    private static Lazy<IBrowser> s_browser = new Lazy<IBrowser>(s_browserFactory, LazyThreadSafetyMode.ExecutionAndPublication);
    private static Lazy<ElementFactory> s_lazyFactory = new Lazy<ElementFactory>(s_factoryFactory, LazyThreadSafetyMode.ExecutionAndPublication);

    public static IBrowser Browser
    {
        get
        {
            if (s_browser.IsValueCreated && s_browser.Value.WebDriver.SessionId is null)
            {
                s_browser = new Lazy<IBrowser>(s_browserFactory, LazyThreadSafetyMode.ExecutionAndPublication);
            }
            
            return s_browser.Value;
        }
    }

    public static ElementFactory Factory
    {
        get
        {
            if (s_lazyFactory.IsValueCreated && s_lazyFactory.Value.IsDisposed)
            {
                s_lazyFactory = new Lazy<ElementFactory>(s_factoryFactory, LazyThreadSafetyMode.ExecutionAndPublication);
            }
            
            return s_lazyFactory.Value;
        }
    }
}