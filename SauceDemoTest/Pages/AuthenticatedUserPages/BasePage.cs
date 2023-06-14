using Core.BrowserFactory;
using Core.SeleniumWrapper;
using Core.SeleniumWrapper.ElementsFactory;
using Core.Utilities;
using SauceDemoTest.AppConfigurations;
using SauceDemoTest.Pages.Components;

namespace SauceDemoTest.Pages.AuthenticatedUserPages;

public abstract class BasePage : BaseForm
{
    protected ElementFactory Factory { get; }
    public BurgerMenu BurgerMenu { get; }
    public Header Header { get; }
    public Footer Footer { get; }

    protected BasePage(string pageName) : base(pageName)
    {
        BurgerMenu = new BurgerMenu();
        Header = new Header();
        Footer = new Footer();
        Factory = EntityContainer.Factory;
    }

    protected override IBrowser Browser => EntityContainer.Browser;
    protected override string BaseUrl => AppConfiguration.BaseUrl;
    protected override string UrlPath => string.Empty;

    public override bool IsPageOpened
    {
        get
        {
            if (Header.PageTitle.Equals(SubTitle))
            {
                Logger.Instance.Debug($"Page {PageName} is open.");
                
                return true;
            }

            Logger.Instance.Warn($"Page {PageName} is not open: page title was different from '{SubTitle}'.");

            return false;
        }
    }

    protected abstract string SubTitle { get; }
}