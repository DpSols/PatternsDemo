using System.ComponentModel;
using Core.BrowserFactory.ConcreteFactories;
using Core.Utilities;

namespace Core.BrowserFactory;
public class BrowserService
{
    public BrowserService()
    {
        _browserName = BrowserNames.Chrome;
        _browserOptions = new[] { "--headless" };
    }
    public BrowserService(string[] browserOptions, BrowserNames browserName)
    {
        _browserName = browserName;
        _browserOptions = browserOptions;
    }

    private static readonly ThreadLocal<IBrowser> s_browserContainer = new ThreadLocal<IBrowser>();
    private static readonly ThreadLocal<BrowserFactory> s_browserFactoryContainer = new ThreadLocal<BrowserFactory>();
    private static bool IsApplicationStarted => s_browserContainer.IsValueCreated && s_browserContainer.Value.IsStarted;
    private readonly BrowserNames _browserName;
    private readonly string[] _browserOptions;
    
    public IBrowser Browser
    {
        get
        {
            if (_browserName != 0)
            {
                if (!IsApplicationStarted)
                {
                    Logger.Instance.Debug($"Getting browser the first time.");
                    s_browserContainer.Value = BrowserFactory.GetBrowser;
                }
                Logger.Instance.Debug($"Calling Browser property.");
                return s_browserContainer.Value;
            }
            
            Logger.Instance.Fatal("Browser name has not be set!");
            throw new InvalidOperationException("The BrowserName property should be set.");
        }
    }
        
    private BrowserFactory BrowserFactory
    {
        get
        {
            if (s_browserFactoryContainer.IsValueCreated) return s_browserFactoryContainer.Value;
            
            Logger.Instance.Debug($"Getting BrowserFactory the first time.");
            SetFactory();

            return s_browserFactoryContainer.Value;
        }
    }

    private void SetFactory()
    {
        switch (_browserName)
        {
            case BrowserNames.Chrome:
                Logger.Instance.Debug($"Setting Chrome configs in SetFactory().");

                s_browserFactoryContainer.Value = new ChromeFactory();
                if (_browserOptions.Length > 0)
                {
                    BrowserFactory.BrowserOptions = _browserOptions;
                }
                break;
            default:
                var errorMessage = $"Value {_browserName} is not yet supported.";
                Logger.Instance.Error(errorMessage);
                throw new InvalidEnumArgumentException(errorMessage);
        }
    }
}