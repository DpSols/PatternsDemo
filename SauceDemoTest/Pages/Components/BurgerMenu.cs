using Core.SeleniumWrapper.Elements;
using Core.SeleniumWrapper.ElementsFactory;
using OpenQA.Selenium;
using SauceDemoTest.AppConfigurations;

namespace SauceDemoTest.Pages.Components;

public sealed class BurgerMenu
{
    private ElementFactory Factory { get; }

    public BurgerMenu()
    {
        Factory = EntityContainer.Factory;
    }
    
    private static readonly By s_crossButtonLocator = By.Id("react-burger-cross-btn");
    private static readonly By s_inventoryLinkLocator = By.Id("inventory_sidebar_link");
    private static readonly By s_aboutLinkLocator = By.Id("about_sidebar_link");
    private static readonly By s_logoutLinkLocator = By.Id("logout_sidebar_link");
    private static readonly By s_resetAppLinkLocator = By.Id("reset_sidebar_link");
    
    private IButtonElement CrossButton => Factory.CreateElement<IButtonElement>(s_crossButtonLocator, nameof(CrossButton));
    private ILinkElement InventoryLink => Factory.CreateElement<ILinkElement>(s_inventoryLinkLocator, nameof(InventoryLink));
    private ILinkElement AboutLink => Factory.CreateElement<ILinkElement>(s_aboutLinkLocator, nameof(AboutLink));
    private ILinkElement LogoutLink => Factory.CreateElement<ILinkElement>(s_logoutLinkLocator, nameof(LogoutLink));
    private ILinkElement ResetAppLink => Factory.CreateElement<ILinkElement>(s_resetAppLinkLocator, nameof(ResetAppLink));

    public bool IsBurgerMenuOpen => CrossButton.Displayed;

    public void CloseBurgerMenu()
    {
        CrossButton.Click();
    }

    public void OpenInventoryLink()
    {
        InventoryLink.Click();
    }

    public void OpenAboutLink()
    {
        AboutLink.Click();
    }

    public void OpenLogoutLink()
    {
        LogoutLink.Click();
    }

    public void OpenResetAppLink()
    {
        ResetAppLink.Click();
    }
}