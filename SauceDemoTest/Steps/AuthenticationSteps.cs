using Core.Utilities;
using NUnit.Allure.Attributes;
using SauceDemoTest.Models;
using SauceDemoTest.Pages.UnauthenticatedUserPages;

namespace SauceDemoTest.Steps;

public sealed class AuthenticationSteps
{
    private readonly LoginPage _loginPage;
    
    public AuthenticationSteps()
    {
        _loginPage = new LoginPage("Login page");
    }

    [AllureStep($"Entering Authentication Credentials")]
    public AuthenticationSteps EnterAuthenticationCredentials(UserCredentials credentials)
    {
        ValidatePage();
        
        Logger.Instance.Info("Entering Authentication Credentials");

        _loginPage.EnterUsername(credentials.Username);
        _loginPage.EnterPassword(credentials.Password);
        
        return this;
    }

    [AllureStep($"Login into system")]
    public AuthenticationSteps Login()
    {
        ValidatePage();
        
        Logger.Instance.Info("Authenticating into system");

        _loginPage.Login();
        
        return this;
    }

    [AllureStep("ClearCredentialFields")]
    public AuthenticationSteps ClearCredentialFields()
    {
        ValidatePage();
        
        Logger.Instance.Info("ClearCredentialFields");

        _loginPage.ErrorButtonClick();
        _loginPage.ClearUsername();
        _loginPage.ClearPassword();
        return this;
    }

    [AllureStep($"Opening Home page")]
    public AuthenticationSteps OpenAuthentication()
    {
        Logger.Instance.Info("Opening home page");
        
        _loginPage.OpenPage();
        
        return this;
    }
    
    private void ValidatePage()
    {
        if (_loginPage.IsPageOpened) return;
        
        var message = $"First open the {_loginPage.PageName}";
        Logger.Instance.Error(message);

        throw new InvalidOperationException(message);
    }
}