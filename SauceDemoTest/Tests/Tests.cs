using Allure.Net.Commons;
using Core.BrowserFactory;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SauceDemoTest.AppConfigurations;
using SauceDemoTest.Pages.AuthenticatedUserPages;
using SauceDemoTest.Steps;
using SauceDemoTest.UIRepository;

namespace SauceDemoTest.Tests;

[AllureNUnit]
[AllureParentSuite("E2E tests")]
public abstract class Tests
{
    private IBrowser Browser => EntityContainer.Browser;
    protected InventoryPage InventoryPage { get; private set; }
    protected CartPage CartPage { get; private set; }
    protected AuthenticationSteps AuthenticationSteps { get; private set; }
    protected ItemPageSteps ItemPageSteps { get; private set; }
    protected CheckoutFirstPageSteps CheckoutFirstPageSteps { get; private set; }
    protected InventoryPageSteps InventoryPageSteps { get; private set; }
    protected InventoryRepository InventoryRepository { get; private set; }
    protected CartRepository CartRepository { get; private set; }
    protected CheckoutSecondPage CheckoutSecondPage { get; private set; }
    protected CheckoutCompletePage CheckoutCompletePage { get; private set; }

    [OneTimeSetUp]
    public void OneTimeSetUpAndCleanUpResults()
    {
        AllureExtensions.WrapSetUpTearDownParams(() => { AllureLifecycle.Instance.CleanupResultDirectory(); },
            "Clear Allure Results Directory");
    }

    [SetUp]
    public void SetUp()
    {
        AuthenticationSteps = new AuthenticationSteps();
        CheckoutFirstPageSteps = new CheckoutFirstPageSteps();
        InventoryPageSteps = new InventoryPageSteps();
        ItemPageSteps = new ItemPageSteps();
        InventoryPage = new InventoryPage("Inventory Page");
        CartPage = new CartPage("Cart Page");
        InventoryRepository = new InventoryRepository();
        CartRepository = new CartRepository();
        CheckoutSecondPage = new CheckoutSecondPage("Second Checkout page");
        CheckoutCompletePage = new CheckoutCompletePage("Checkout complete page");
    }

    [TearDown]
    public void TearDown()
    {
        Browser.WebDriver.Quit();
    }
}