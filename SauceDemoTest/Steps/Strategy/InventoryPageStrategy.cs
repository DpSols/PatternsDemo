using Core.Utilities;
using SauceDemoTest.Pages.AuthenticatedUserPages;

namespace SauceDemoTest.Steps.Strategy;

public sealed class InventoryPageStrategy : IStrategy
{
    private readonly InventoryPage _inventoryPage;

    public InventoryPageStrategy()
    {
        _inventoryPage = new InventoryPage("Inventory page");
    }
    
    public void RemoveFromCart(int index)
    {
        _inventoryPage.ItemRemoveFromCart(index);
    }

    public void RemoveFromCart(string name)
    {
        _inventoryPage.ItemRemoveFromCart(name);
    }

    public void AddToCart(int index)
    {
        _inventoryPage.ItemAddToCart(index);
    }

    public void AddToCart(string name)
    {
        _inventoryPage.ItemAddToCart(name);
    }
}