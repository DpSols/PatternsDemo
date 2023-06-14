using NUnit.Allure.Attributes;
using SauceDemoTest.Pages.AuthenticatedUserPages;

namespace SauceDemoTest.Steps;

public sealed class ItemPageSteps
{
    private readonly ItemPage _itemPage;
    
    public ItemPageSteps()
    {
        _itemPage = new ItemPage("Item Page");
    }

    [AllureStep("Add To Cart")]
    public ItemPageSteps AddToCart()
    {
        if (_itemPage.IsInCart) return this;
        
        _itemPage.AddToCart();
        return this;
    }

    [AllureStep("Remove From Cart")]
    public ItemPageSteps RemoveFromCart()
    {
        if (!_itemPage.IsInCart) return this;
        
        _itemPage.RemoveFromCart();
        return this;
    }

    [AllureStep("Go to inventory")]
    public ItemPageSteps GoToInventory()
    {
        _itemPage.BackToInventory();
        return this;
    }
}