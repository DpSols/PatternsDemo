using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.BrowserFactory
{
    public interface IBrowser
    {
        public IBrowser SetImplicitTime();
        public IBrowser MaximizeWindow();
        public void Quit();
        public IBrowser Close();
        public IBrowser GoToUrl(string url);
        public IBrowser GoToUrl(Uri uri);
        public bool IsStarted { get; }
        public WebDriver WebDriver { get; }
        public WebDriverWait WebDriverWait { get; }
    }
}