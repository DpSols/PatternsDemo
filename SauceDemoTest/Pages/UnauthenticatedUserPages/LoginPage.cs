using Core.BrowserFactory;
using Core.SeleniumWrapper;
using Core.SeleniumWrapper.Elements;
using Core.SeleniumWrapper.ElementsFactory;
using Core.Utilities;
using OpenQA.Selenium;
using SauceDemoTest.AppConfigurations;

namespace SauceDemoTest.Pages.UnauthenticatedUserPages;

public sealed class LoginPage : BaseForm
{
    private ElementFactory Factory { get; }

    public LoginPage(string pageName) : base(pageName)
    { 
        Factory = EntityContainer.Factory;
    }

    protected override IBrowser Browser => EntityContainer.Browser;
    protected override string BaseUrl => AppConfiguration.BaseUrl;
    protected override string UrlPath => string.Empty;

    private static readonly By s_logoLocator = By.ClassName("login_logo");
    private static readonly By s_usernameLocator = By.Id("user-name");
    private static readonly By s_passwordLocator = By.Id("password");
    private static readonly By s_loginButtonLocator = By.Id("login-button");
    private static readonly By s_errorButtonLocator = By.ClassName("error-button");

    private ILabelElement Logo => Factory.CreateElement<ILabelElement>(s_logoLocator, nameof(Logo));
    private IInputElement UsernameInput => Factory.CreateElement<IInputElement>(s_usernameLocator, nameof(UsernameInput));
    private IInputElement PasswordInput => Factory.CreateElement<IInputElement>(s_passwordLocator, nameof(PasswordInput));
    private IButtonElement LoginButton => Factory.CreateElement<IButtonElement>(s_loginButtonLocator, nameof(LoginButton));
    private IButtonElement ErrorButton => Factory.CreateElement<IButtonElement>(s_errorButtonLocator, nameof(ErrorButton));

    public override bool IsPageOpened
    {
        get
        {
            try
            {
                return Logo.Displayed;
            }
            catch (NoSuchElementException e)
            {
                Logger.Instance.Warn($"Page is not opened because {e}.");
                return false;
            }
        }
    }

    public void ErrorButtonClick()
    {
        ErrorButton.Click();
    }
    
    public void EnterUsername(string username)
    {
        UsernameInput.Input(username);
    }
    
    public void EnterPassword(string password)
    {
        PasswordInput.Input(password);
    }
    
    public void ClearUsername()
    {
        UsernameInput.Clear();
    }
    
    public void ClearPassword()
    {
        PasswordInput.Clear();
    }

    public void Login()
    {
        LoginButton.Click();
    }
}