using System.Collections.ObjectModel;
using Core.SeleniumWrapper.Elements;
using Core.SeleniumWrapper.ElementsFactory;
using Core.Utilities;
using OpenQA.Selenium;
using SauceDemoTest.AppConfigurations;

namespace SauceDemoTest.Pages.Components;

public sealed class Header
{
    private ElementFactory Factory { get; }

    public Header()
    {
        Factory = EntityContainer.Factory;
    }
    
    private static readonly By s_burgerButtonLocator = By.Id("react-burger-menu-btn");
    private static readonly By s_cartButtonLocator = By.Id("shopping_cart_container");
    private static readonly By s_appLogoLocator = By.ClassName("app_logo");
    private static readonly By s_cartCounterLocator = By.ClassName("shopping_cart_badge");
    private static readonly By s_pageTitleLocator = By.ClassName("title");
    
    
    private ReadOnlyCollection<ILabelElement> PageTitleLabel => 
        Factory.CreateElements<ILabelElement>(s_pageTitleLocator, nameof(PageTitleLabel));
    private ILabelElement CartCounter => 
        Factory.CreateElement<ILabelElement>(s_cartCounterLocator, nameof(CartCounter));
    private IButtonElement BurgerButton => Factory.CreateElement<IButtonElement>(s_burgerButtonLocator, nameof(BurgerButton));
    private IButtonElement CartButton => Factory.CreateElement<IButtonElement>(s_cartButtonLocator, nameof(CartButton));
    private ILabelElement AppLogo => Factory.CreateElement<ILabelElement>(s_appLogoLocator, nameof(AppLogo));

    public void OpenBurgerMenu()
    {
        Logger.Instance.Debug("Opening the burger menu.");

        BurgerButton.Click();
    }

    public void OpenCart()
    {
        Logger.Instance.Debug("Opening the cart.");
        
        CartButton.Click();
    }

    public int ItemInCartCounterBadge
    {
        get
        {
            int count = int.Parse(CartCounter.Text);
            Logger.Instance.Debug($"The badge shows {count}.");
            
            return count;
        }
    }
    
    public string PageTitle
    {
        get
        {
            if (PageTitleLabel.Count != 1) return string.Empty;
            
            var title = PageTitleLabel.First().Text;
            Logger.Instance.Debug($"The title is {title}.");

            return title;
        }
    }

    public bool LogoDisplayed
    {
        get
        {
            var displayed = AppLogo.Displayed;
            Logger.Instance.Debug($"The logo is displayed: {displayed}");

            return displayed;
        }
    }
}