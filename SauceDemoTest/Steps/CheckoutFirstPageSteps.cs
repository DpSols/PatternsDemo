using Core.Utilities;
using NUnit.Allure.Attributes;
using SauceDemoTest.Models;
using SauceDemoTest.Pages.AuthenticatedUserPages;

namespace SauceDemoTest.Steps;

public class CheckoutFirstPageSteps
{
    private readonly CheckoutFirstPage _checkoutFirstPage;
    
    public CheckoutFirstPageSteps()
    {
        _checkoutFirstPage = new CheckoutFirstPage("Checkout step one page");
    }

    [AllureStep($"Proceeding the checkout.")]
    public CheckoutFirstPageSteps ProceedCheckout(UserCredentials credentials)
    {
        ValidatePage();

        Logger.Instance.Info("Proceeding the checkout.");
        _checkoutFirstPage.EnterFirstName(credentials.FirstName);
        _checkoutFirstPage.EnterLastName(credentials.LastName);
        _checkoutFirstPage.EnterZipCode(credentials.PostalCode);
        _checkoutFirstPage.Continue();

        return this;
    }

    [AllureStep("Canceling the checkout.")]
    public CheckoutFirstPageSteps CancelCheckout()
    {
        ValidatePage();

        Logger.Instance.Info("Canceling the checkout.");
        _checkoutFirstPage.Cancel();

        return this;
    }
    
    private void ValidatePage()
    {
        if (!_checkoutFirstPage.IsPageOpened)
        {
            var message = $"First open the {_checkoutFirstPage.PageName}";
            Logger.Instance.Error(message);

            throw new InvalidOperationException(message);
        }
    }
}