using SauceDemoTest.Models;
using SauceDemoTest.Pages.AuthenticatedUserPages;

namespace SauceDemoTest.UIRepository;

public class CartRepository
{
    private readonly CartPage _cartPage;

    public CartRepository()
    {
        _cartPage = new CartPage("Cart page");
    }

    public List<Item> GetItems()
    {
        var inventoryCount = _cartPage.GetCartItemCount;
        var items = new List<Item>();
        
        for (int i = 0; i < inventoryCount; i++)
        {
            items.Add(
                new Item(
                    ItemName: _cartPage.GetItemName(i),
                    ItemDescription: _cartPage.GetItemDescription(i),
                    ItemPrice: _cartPage.GetItemPrice(i),
                    ItemQuantity: _cartPage.GetItemQuantity(i)
                )
            );
        }

        return items;
    }
}