using Core.Utilities;
using NUnit.Allure.Attributes;
using SauceDemoTest.Pages.AuthenticatedUserPages;

namespace SauceDemoTest.Steps;

public sealed class InventoryPageSteps
{
    private readonly InventoryPage _inventoryPage;

    public InventoryPageSteps()
    {
        _inventoryPage = new InventoryPage("Inventory Page");
    }

    [AllureStep("Adding items with names #{0}.")]
    public InventoryPageSteps AddToCartItems(string[] names)
    {
        ValidatePage();
        
        foreach (string name in names)
        {
            Logger.Instance.Info($"Adding {name} item to cart from Inventory.");
            _inventoryPage.ItemAddToCart(name);
        }
        
        return this;
    }

    [AllureStep("Filtering inventory on #{0}")]
    public InventoryPageSteps Filter(string value)
    {
        Logger.Instance.Info($"Applying {value} filter to Inventory.");
        _inventoryPage.SelectFilter(value);

        return this;
    }
    
    [AllureStep("Removing items with names #{0}")]
    public InventoryPageSteps RemoveFromCartItems(string[] names)
    {
        ValidatePage();
        
        foreach (string name in names)
        {
            Logger.Instance.Info($"Removing {name} item from cart from Inventory page.");
            _inventoryPage.ItemRemoveFromCart(name);
        }
        
        return this;
    }

    [AllureStep("Open the Cart")]
    public InventoryPageSteps OpenCart()
    {
        ValidatePage();

        Logger.Instance.Info("Opening Cart From Inventory.");
        _inventoryPage.Header.OpenCart();
        
        return this;
    }

    [AllureStep("Open item page")]
    public InventoryPageSteps OpenItemPage(int index)
    {
        ValidatePage();
        _inventoryPage.OpenItemLink(index);

        return this;
    }

    private void ValidatePage()
    {
        if (_inventoryPage.IsPageOpened) return;
        
        var message = $"First open the {_inventoryPage.PageName}";
        Logger.Instance.Error(message);

        throw new InvalidOperationException(message);
    }
}