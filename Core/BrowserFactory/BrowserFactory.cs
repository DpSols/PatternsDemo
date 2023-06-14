using Core.BrowserFactory.ConcreteBrowsers;
using OpenQA.Selenium;

namespace Core.BrowserFactory
{
    public abstract class BrowserFactory
    {
        public string[] BrowserOptions { get; set; }
        public IBrowser GetBrowser => new Browser(WebDriver);
        protected abstract WebDriver WebDriver { get; }
    }
}