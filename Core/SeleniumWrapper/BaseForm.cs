using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Core.Utilities;
using Core.BrowserFactory;

namespace Core.SeleniumWrapper;

public abstract class BaseForm
{
    private readonly IJavaScriptExecutor _jsExecutor;
    public string PageName { get; }
    private WebDriver WebDriver => Browser.WebDriver;
    protected abstract IBrowser Browser { get; }
    protected abstract string BaseUrl { get; }
    protected abstract string UrlPath { get; }
    protected WebDriverWait WebDriverWait => Browser.WebDriverWait;

    protected BaseForm(string pageName)
    {
        _jsExecutor = WebDriver;
        PageName = pageName;
    }

    public string Title => WebDriver.Title;

    public void OpenPage()
    {
        var uri = new Uri(BaseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        Logger.Instance.Debug($"Opening page {PageName}");
        Browser.GoToUrl(uri);
        WaitForElementAppear();
    }

    public abstract bool IsPageOpened { get; }

    private void WaitForElementAppear()
    {
        WebDriverWait.Until(_ => _jsExecutor.ExecuteScript("return document.readyState").Equals("complete"));
    }
}