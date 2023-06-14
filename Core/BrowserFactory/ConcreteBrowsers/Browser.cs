using Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.BrowserFactory.ConcreteBrowsers;

internal class Browser : IBrowser
{
    public bool IsStarted => WebDriver.SessionId != null;

    public WebDriver WebDriver { get; }
    public WebDriverWait WebDriverWait => new WebDriverWait(WebDriver, TimeSpan.FromSeconds(7));

    public Browser(WebDriver webDriver)
    {
        WebDriver = webDriver;
        MaximizeWindow();
        SetImplicitTime();
    }
    public IBrowser Close()
    {

        Logger.Instance.Info("Closing the tab.");
        WebDriver.Close();
        return this;
    }

    public IBrowser GoToUrl(string uri)
    {
        Logger.Instance.Debug($"Navigating to {uri}");
        WebDriver.Navigate().GoToUrl(uri);
        return this;
    }

    public IBrowser GoToUrl(Uri uri)
    {
        GoToUrl(uri.ToString());
        return this;
    }

    public IBrowser MaximizeWindow()
    {
        Logger.Instance.Debug("Maximizing the window.");
        WebDriver.Manage().Window.Maximize();
        return this;
    }

    public void Quit()
    {
        Logger.Instance.Debug("Ending the browser session.");
        WebDriver.Quit();
    }

    public IBrowser SetImplicitTime()
    {
        int seconds = 5;
        Logger.Instance.Debug($"Setting implicit waiter to {seconds} sec.");
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        return this;
    }
}