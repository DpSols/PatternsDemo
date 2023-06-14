using Core.SeleniumWrapper.Elements;
using Core.Utilities;
using OpenQA.Selenium;

namespace SauceDemoTest.Pages.AuthenticatedUserPages;

public sealed class CheckoutCompletePage : BasePage
{
    public CheckoutCompletePage(string pageName) : base(pageName)
    {
    }
    
    private static readonly By s_completeHeaderLocator = By.ClassName("complete-header");
    private static readonly By s_completeTextLocator = By.ClassName("complete-text");
    private static readonly By s_backHomeButtonLocator = By.Id("back-to-products");
    
    private IInputElement CompleteHeader => Factory.CreateElement<IInputElement>(s_completeHeaderLocator, nameof(CompleteHeader));
    private IInputElement CompleteText => Factory.CreateElement<IInputElement>(s_completeTextLocator, nameof(CompleteText));
    private IButtonElement CompleteBackHomeButton => Factory.CreateElement<IButtonElement>(s_backHomeButtonLocator, nameof(CompleteBackHomeButton));

    protected override string UrlPath => "/checkout-complete.html";
    protected override string SubTitle => "Checkout: Complete!";

    public string GetCompleteHeader
    {
        get
        {
            Logger.Instance.Debug("Getting Complete Header text.");
            return CompleteHeader.Text;
        }
    }

    public string GetCompleteText
    {
        get
        {
            Logger.Instance.Debug("Getting Complete text.");
            return CompleteText.Text;
        }
    }

    public void BackHome()
    {
        Logger.Instance.Debug("Getting Complete text.");
        CompleteBackHomeButton.Click();
    }
}