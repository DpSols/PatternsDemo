using SauceDemoTest.Models;
using SauceDemoTest.Pages.AuthenticatedUserPages;

namespace SauceDemoTest.UIRepository;

public class InventoryRepository
{
    private readonly InventoryPage _inventoryPage;

    public InventoryRepository()
    {
        _inventoryPage = new InventoryPage("Inventory page");
    }

    public List<Item> GetInventoryItems()
    {
        if (!_inventoryPage.IsPageOpened) return new List<Item>();
        
        var inventoryCount = _inventoryPage.GetInventoryCount;
        var items = new List<Item>();
        
        for (int i = 0; i < inventoryCount; i++)
        {
            items.Add(
                new Item(
                    ItemName: _inventoryPage.GetItemName(i),
                    ItemDescription: _inventoryPage.GetItemDescription(i),
                    ItemPrice: _inventoryPage.GetItemPrice(i))
            );
        }

        return items;
    }
}