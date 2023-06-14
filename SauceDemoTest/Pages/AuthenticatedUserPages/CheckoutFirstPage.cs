using Core.SeleniumWrapper.Elements;
using Core.Utilities;
using OpenQA.Selenium;

namespace SauceDemoTest.Pages.AuthenticatedUserPages;

public sealed class CheckoutFirstPage : BasePage
{
    public CheckoutFirstPage(string pageName) : base(pageName)
    {
    }
    
    private static readonly By s_firstNameLocator = By.Id("first-name");
    private static readonly By s_lastNameLocator = By.Id("last-name");
    private static readonly By s_zipCodeLocator = By.Id("postal-code");
    private static readonly By s_cancelButtonLocator = By.Id("cancel");
    private static readonly By s_continueButtonLocator = By.Id("continue");

    private IInputElement FirstNameInput => Factory.CreateElement<IInputElement>(s_firstNameLocator, nameof(FirstNameInput));
    private IInputElement LastNameInput => Factory.CreateElement<IInputElement>(s_lastNameLocator, nameof(LastNameInput));
    private IInputElement ZipCodeInput => Factory.CreateElement<IInputElement>(s_zipCodeLocator, nameof(ZipCodeInput));
    private IButtonElement CancelButton => Factory.CreateElement<IButtonElement>(s_cancelButtonLocator, nameof(CancelButton));
    private IButtonElement ContinueButton => Factory.CreateElement<IButtonElement>(s_continueButtonLocator, nameof(ContinueButton));

    protected override string UrlPath => "/checkout-step-one.html";
    protected override string SubTitle => "Checkout: Your Information";

    public void EnterFirstName(string firstName)
    {
        Logger.Instance.Debug($"Sending {firstName} to first name input.");
        
        FirstNameInput.Input(firstName);
    }

    public void EnterLastName(string lastName)
    {
        Logger.Instance.Debug($"Sending {lastName} to last name input.");
        
        LastNameInput.Input(lastName);
    }

    public void EnterZipCode(string zipCode)
    {
        Logger.Instance.Debug($"Sending {zipCode} to zip code input.");
        
        ZipCodeInput.Input(zipCode);
    }

    public void Cancel()
    {
        Logger.Instance.Debug($"Canceling the checkout.");
        
        CancelButton.Click();
    }

    public void Continue()
    {
        Logger.Instance.Debug($"Continuing the checkout.");
        
        ContinueButton.Click();
    }
}