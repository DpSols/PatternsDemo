using System.Collections.ObjectModel;
using System.Text;
using Core.SeleniumWrapper.Elements;
using Core.Utilities;
using OpenQA.Selenium;
using SauceDemoTest.Utilities;

namespace SauceDemoTest.Pages.AuthenticatedUserPages;

public sealed class CartPage : BasePage
{
    public CartPage(string pageName) : base(pageName)
    {
    }
    
    private static readonly By s_itemNameLocator = By.ClassName("inventory_item_name");
    private static readonly By s_itemDescriptionLocator = By.ClassName("inventory_item_desc");
    private static readonly By s_itemPriceLocator = By.ClassName("inventory_item_price");
    private static readonly By s_itemCartQuantityLocator = By.ClassName("cart_quantity");
    private static readonly By s_continueShoppingButtonLocator = By.Id("continue-shopping");
    private static readonly By s_checkoutButtonLocator = By.Id("checkout");

    private static By s_removeItemButtonByNameLocator(string name)
    {
        var locatorPrefix = "remove-";
        var stringBuilder = new StringBuilder(locatorPrefix + name.ToLower());
        stringBuilder.Replace(" ", "-");
        var locator = By.Id(stringBuilder.ToString());
        
        return locator;
    }

    private ReadOnlyCollection<ILabelElement> ItemName => Factory.CreateElements<ILabelElement>(s_itemNameLocator, nameof(ItemName));
    private ReadOnlyCollection<ILabelElement> ItemDescription => Factory.CreateElements<ILabelElement>(s_itemDescriptionLocator, nameof(ItemDescription));
    private ReadOnlyCollection<ILabelElement> ItemPrice => Factory.CreateElements<ILabelElement>(s_itemPriceLocator, nameof(ItemPrice));
    private ReadOnlyCollection<ILabelElement> ItemCartQuantity => Factory.CreateElements<ILabelElement>(s_itemCartQuantityLocator, nameof(ItemCartQuantity));
    private IButtonElement RemoveItemButtonByName(string name) => Factory.CreateElement<IButtonElement>(s_removeItemButtonByNameLocator(name), nameof(RemoveItemButtonByName));
    private IButtonElement ContinueShoppingButton => Factory.CreateElement<IButtonElement>(s_continueShoppingButtonLocator, nameof(ContinueShoppingButton));
    private IButtonElement CheckoutButton => Factory.CreateElement<IButtonElement>(s_checkoutButtonLocator, nameof(CheckoutButton));

    protected override string UrlPath => "/cart.html";
    protected override string SubTitle => "Your Cart";

    public void RemoveItemByName(string name)
    {
        Logger.Instance.Debug($"Removing {name} item from cart.");
        
        RemoveItemButtonByName(name).Click();
    }

    public void ContinueShopping()
    {
        Logger.Instance.Debug("Continuing shopping.");
        
        ContinueShoppingButton.Click();
    }

    public void Checkout()
    {
        Logger.Instance.Debug("Processing to checkout.");
        
        CheckoutButton.Click();
    }
    
    public int GetCartItemCount
    {
        get
        {
            int count = ItemName.Count;
            Logger.Instance.Debug($"There are {count} items on Inventory.");
            
            return ItemName.Count;
        }
    }

    public string GetItemName(int index)
    {
        Logger.Instance.Debug($"Getting {index} item name.");
        
        return ItemName[index].Text;
    }

    public string GetItemDescription(int index)
    {
        Logger.Instance.Debug($"Getting {index} item description.");
        
        return ItemDescription[index].Text;
    }

    public float GetItemPrice(int index)
    {
        Logger.Instance.Debug($"Getting {index} item price.");
        var text = ItemPrice[index].Text;
        var price = Converter.PriceToFloat(text);
        
        return price;
    }

    public int GetItemQuantity(int index)
    {
        Logger.Instance.Debug($"Getting {index} item quantity.");

        if (!int.TryParse(ItemCartQuantity[index].Text, out int quantity))
        {
            Logger.Instance.Error("Quantity was not in expected format!");
            return 0;
        }
        
        return quantity;
    }
}