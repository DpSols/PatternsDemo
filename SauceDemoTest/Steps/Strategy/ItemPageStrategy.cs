using Core.Utilities;
using SauceDemoTest.Pages.AuthenticatedUserPages;

namespace SauceDemoTest.Steps.Strategy;

public sealed class ItemPageStrategy : IStrategy
{
    private readonly ItemPage _itemPage;
    private readonly InventoryPage _inventoryPage;
    
    public ItemPageStrategy()
    {
        _itemPage = new ItemPage("Item Page");
        _inventoryPage = new InventoryPage("Inventory Page");
    }
    
    public void RemoveFromCart(int index)
    {
        _inventoryPage.OpenItemLink(index);

        if (!_itemPage.IsInCart)
        {
            Logger.Instance.Warn($"Item {index} was not in cart.");
            
            return;
        }
        
        _itemPage.RemoveFromCart();
    }

    public void RemoveFromCart(string name)
    {
        for (int i = 0; i < _inventoryPage.GetInventoryCount; i++)
        {
            if (_inventoryPage.GetItemName(i) != name) continue;
            
            RemoveFromCart(i);
            
            return;
        }
    }

    public void AddToCart(int index)
    {
        _inventoryPage.OpenItemLink(index);
        
        if (_itemPage.IsInCart)
        {
            Logger.Instance.Warn($"Item {index} was already in cart.");
            
            return;
        }
        
        _itemPage.AddToCart();
    }

    public void AddToCart(string name)
    {
        for (int i = 0; i < _inventoryPage.GetInventoryCount; i++)
        {
            if (_inventoryPage.GetItemName(i) != name) continue;
            
            AddToCart(i);
            
            return;
        }
    }
}