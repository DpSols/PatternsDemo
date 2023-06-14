using System.Collections.ObjectModel;
using System.Text;
using Core.SeleniumWrapper.Elements;
using Core.Utilities;
using OpenQA.Selenium;
using SauceDemoTest.Utilities;

namespace SauceDemoTest.Pages.AuthenticatedUserPages;

public sealed class InventoryPage : BasePage
{
    public InventoryPage(string pageName) : base(pageName)
    {
    }

    private static readonly By s_itemNameLocator = By.ClassName("inventory_item_name");
    private static readonly By s_itemDescriptionLocator = By.ClassName("inventory_item_desc");
    private static readonly By s_itemPriceLocator = By.ClassName("inventory_item_price");
    private static readonly By s_addToCartButtonLocator = By.CssSelector(".btn.btn_primary.btn_small.btn_inventory");
    private static readonly By s_removeFromCartButtonLocator = By.CssSelector(".btn.btn_secondary.btn_small.btn_inventory");
    private static readonly By s_filterSelectLocator = By.ClassName("product_sort_container");

    private static By s_itemAddToCartByNameLocator(string name)
    {
        var locatorPrefix = "add-to-cart-";
        var stringBuilder = new StringBuilder(locatorPrefix + name.ToLower());
        stringBuilder.Replace(" ", "-");
        var locator = By.Id(stringBuilder.ToString());

        return locator;
    }

    private static By s_itemRemoveFromCartByNameLocator(string name)
    {
        var locatorPrefix = "remove-";
        var stringBuilder = new StringBuilder(locatorPrefix + name.ToLower());
        stringBuilder.Replace(" ", "-");
        var locator = By.Id(stringBuilder.ToString());

        return locator;
    }

    private ISelectingElement FilterSelect => 
        Factory.CreateElement<ISelectingElement>(s_filterSelectLocator, nameof(FilterSelect));
    private ReadOnlyCollection<ILinkElement> ItemNameLink => 
        Factory.CreateElements<ILinkElement>(s_itemNameLocator, nameof(ItemNameLink));
    private ReadOnlyCollection<ILabelElement> ItemDescription => 
        Factory.CreateElements<ILabelElement>(s_itemDescriptionLocator, nameof(ItemDescription));
    private ReadOnlyCollection<ILabelElement> ItemPrice =>
        Factory.CreateElements<ILabelElement>(s_itemPriceLocator, nameof(ItemPrice));
    private ReadOnlyCollection<IButtonElement> ItemAddToCartButton =>
        Factory.CreateElements<IButtonElement>(s_addToCartButtonLocator, nameof(ItemAddToCartButton));
    private ReadOnlyCollection<IButtonElement> ItemRemoveFromCartButton =>
        Factory.CreateElements<IButtonElement>(s_removeFromCartButtonLocator, nameof(ItemRemoveFromCartButton));

    private IButtonElement ItemRemoveFromCartByNameButton(string name)
    {
        return Factory
            .CreateElement<IButtonElement>(s_itemRemoveFromCartByNameLocator(name), "Remove-From-Cart Button By Name");
    }

    private IButtonElement ItemAddToCartByNameButton(string name)
    {
        return Factory
            .CreateElement<IButtonElement>(s_itemAddToCartByNameLocator(name), "Add-To-Cart Button By Name");
    }

    protected override string UrlPath => "/inventory.html";
    protected override string SubTitle => "Products";

    public int GetInventoryCount
    {
        get
        {
            int count = ItemNameLink.Count;
            Logger.Instance.Debug($"There are {count} items on Inventory.");
            
            return ItemNameLink.Count;
        }
    }

    public string GetItemName(int index)
    {
        Logger.Instance.Debug($"Getting {index} item name.");
        
        return ItemNameLink[index].Text;
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

    public void OpenItemLink(int index)
    {
        Logger.Instance.Debug($"Opening {index} item link.");
        
        ItemNameLink[index].Click();
    }

    public void ItemAddToCart(int index)
    {
        Logger.Instance.Debug($"Adding {index} item.");
        
        ItemAddToCartButton[index].Click();
    }

    public void ItemRemoveFromCart(int index)
    {
        Logger.Instance.Debug($"Removing {index} item.");
        
        ItemRemoveFromCartButton[index].Click();
    }

    public void ItemAddToCart(string name)
    {
        Logger.Instance.Debug($"Adding {name} item.");
        
        ItemAddToCartByNameButton(name).Click();
    }

    public void ItemRemoveFromCart(string name)
    {
        Logger.Instance.Debug($"Removing {name} item.");
        
        ItemRemoveFromCartByNameButton(name).Click();
    }

    public void SelectFilter(string value)
    {
        Logger.Instance.Debug($"Applying {value} filter to Inventory.");
        
        FilterSelect.SelectByValue(value);
    }
}