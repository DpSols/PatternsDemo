using NUnit.Allure.Attributes;
using NUnit.Framework;
using SauceDemoTest.Models;
using SauceDemoTest.Utilities;
using SauceDemoTest.ValueObjects.UserObjects;

namespace SauceDemoTest.Tests.E2ETests;

[AllureSuite("Basic-Flow Test")]
public class EndToEndTests : Tests
{
    [Test]
    [AllureFeature("BasicFlowTest")]
    public void BasicFlowTest()
    {
        UserCredentials credentials = UserRegisteredCredentials.UserCredentialsStandard;
        List<Item> inventoryItems;
        List<Item> itemsAddedToCart = new List<Item>();
        
        const string expectedCompleteHeader = "Thank you for your order!";
        const string expectedCompleteText = "Your order has been dispatched, and will arrive just as fast as the pony can get there!";

        Authenticate(credentials);

        inventoryItems = InventoryRepository.GetInventoryItems();

        for (int i = InventoryPage.GetInventoryCount - 1; i >= 0; i--)
        {
            itemsAddedToCart.Add(inventoryItems[i]);
            InventoryPage.ItemAddToCart(i);
        }

        InventoryPageSteps.OpenCart();
        List<Item> itemsDisplayedInCart = CartRepository.GetItems();
        
        CartPage.Checkout();
        CheckoutFirstPageSteps.ProceedCheckout(credentials);
        
        var expectedSubtotal = itemsAddedToCart.Select(item => item.ItemPrice).Sum();
        var expectedTax = 10.3999996f;
        var expectedTotal = expectedSubtotal + expectedTax;
        
        var actualSubtotal = CheckoutSecondPage.Subtotal;
        var actualTax = CheckoutSecondPage.Tax;
        var actualTotal = CheckoutSecondPage.Total;

        CheckoutSecondPage.Finish();
        
        var completeHeader = CheckoutCompletePage.GetCompleteHeader;
        var completeText =CheckoutCompletePage.GetCompleteText;

        Assert.Multiple(() =>
        {
            Assert.That(itemsAddedToCart, Is.EquivalentTo(itemsDisplayedInCart));
            Assert.That(actualSubtotal, Is.EqualTo(expectedSubtotal));
            Assert.That(actualTax, Is.EqualTo(expectedTax));
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
            Assert.That(completeHeader, Is.EqualTo(expectedCompleteHeader));
            Assert.That(completeText, Is.EqualTo(expectedCompleteText));
        });
    }

    [Test]
    [AllureFeature("Able To continue shopping")]
    public void DisturbedShopping()
    {
        UserCredentials credentials = UserRegisteredCredentials.UserCredentialsStandard;

        Authenticate(credentials);

        var inventoryItems = InventoryRepository.GetInventoryItems()
            .Select(item => item.ItemName);

        InventoryPageSteps
            .AddToCartItems(inventoryItems.ToArray())
            .OpenCart();
        
        InventoryPage.Header.OpenBurgerMenu();
        InventoryPage.BurgerMenu.OpenLogoutLink();
        
        Authenticate(credentials);

        InventoryPageSteps.OpenCart();
        
        Assert.That(inventoryItems, Is.EquivalentTo(CartRepository.GetItems().Select(item => item.ItemName)));
    }

    [Test]
    [TestCase(new []{2,3})]
    [AllureFeature("Able to shop in item page.")]
    public void ShopFromDetails(int[] itemIndex)
    {
        UserCredentials credentials = UserRegisteredCredentials.UserCredentialsStandard;
        const string expectedCompleteHeader = "Thank you for your order!";

        Authenticate(credentials);

        var inventory = InventoryRepository.GetInventoryItems();
        var chosenItemNames = itemIndex.Select((index => inventory[index]));

        foreach (var i in itemIndex)
        {
            InventoryPageSteps.OpenItemPage(i);
            ItemPageSteps
                .AddToCart()
                .GoToInventory();
        }

        InventoryPageSteps.OpenCart();
        List<Item> itemsDisplayedInCart = CartRepository.GetItems();
        
        CartPage.Checkout();
        CheckoutFirstPageSteps.ProceedCheckout(credentials);
        
        CheckoutSecondPage.Finish();
        
        var completeHeader = CheckoutCompletePage.GetCompleteHeader;

        Assert.Multiple(() =>
        {
            Assert.That(itemsDisplayedInCart, Is.EquivalentTo(chosenItemNames));
            Assert.That(completeHeader, Is.EqualTo(expectedCompleteHeader));
        });
    }

    [Test]
    [AllureFeature("Able to filter inventory.")]
    public void AbleToFilter()
    {
        const string expectedCompleteHeader = "Thank you for your order!";
        var credentials = UserRegisteredCredentials.UserCredentialsStandard;

        Authenticate(credentials);

        FilterCheck("lohi");
        FilterCheck("az");
        FilterCheck("hilo");
        FilterCheck("az");

        InventoryPageSteps.OpenCart();
        CartPage.Checkout();
        CheckoutFirstPageSteps.ProceedCheckout(credentials);
        CheckoutSecondPage.Finish();
        
        var completeHeader = CheckoutCompletePage.GetCompleteHeader;
        
        Assert.That(completeHeader, Is.EqualTo(expectedCompleteHeader));
    }

    [Test]
    [AllureFeature("Able to refill credentials if mistaken.")]
    public void AbleToCorrectCredentials()
    {
        // RED test
        var correctCredentials = UserRegisteredCredentials.UserCredentialsStandard;
        var wrongCredentials = UserRegisteredCredentials.UserCredentialsLocked;

        AuthenticationSteps
            .OpenAuthentication()
            .EnterAuthenticationCredentials(wrongCredentials)
            .Login()
            .ClearCredentialFields()
            .EnterAuthenticationCredentials(correctCredentials);
        
        AuthenticationSteps.Login();
        
        Assert.That(InventoryPage.IsPageOpened);
    }

    private void Authenticate(UserCredentials credentials)
    {
        AuthenticationSteps
            .OpenAuthentication()
            .EnterAuthenticationCredentials(credentials)
            .Login();
        
        if (!InventoryPage.IsPageOpened)
        {
            throw new AssertionException("Seems like the wrong credentials has been passed.");
        }
    }

    private void FilterCheck(string value)
    {
        InventoryPageSteps.Filter(value);
        var items = InventoryRepository.GetInventoryItems();
        
        switch (value)
        {
            case "az":
                Assert.That(ItemsSortingValidator.IsSortedByName(items));
                break;
            case "za":
                Assert.That(ItemsSortingValidator.IsSortedByNameReverse(items));
                break;
            case "hilo":
                Assert.That(ItemsSortingValidator.IsSortedDescendingPrice(items));
                break;
            case "lohi":
                Assert.That(ItemsSortingValidator.IsSortedAscendingPrice(items));
                break;
            default:
                throw new ArgumentException("There is no such filter value");
        }
    }
}