using System.Collections.ObjectModel;
using Core.SeleniumWrapper.Elements;
using Core.Utilities;
using OpenQA.Selenium;
using SauceDemoTest.Utilities;

namespace SauceDemoTest.Pages.AuthenticatedUserPages;

public class ItemPage : BasePage
{
    public ItemPage(string pageName) : base(pageName)
    {
    }

    protected override string SubTitle => string.Empty;

    private static readonly By s_backButtonLocator = By.Id("back-to-products");
    private static readonly By s_detailsNameLocator = By.ClassName("inventory_details_name");
    private static readonly By s_detailsDescriptionLocator = By.ClassName("inventory_details_desc");
    private static readonly By s_detailsPriceLocator = By.ClassName("inventory_details_price");
    private static readonly By s_addToCartButtonLocator = By.CssSelector(".btn.btn_primary.btn_small.btn_inventory");
    private static readonly By s_removeFromCartButtonLocator = By.CssSelector(".btn.btn_secondary.btn_small.btn_inventory");
    
    private ILabelElement NameLabel => Factory.CreateElement<ILabelElement>(s_detailsNameLocator, nameof(NameLabel));
    private ILabelElement DescriptionLabel => Factory.CreateElement<ILabelElement>(s_detailsDescriptionLocator, nameof(DescriptionLabel));
    private ILabelElement PriceLabel => Factory.CreateElement<ILabelElement>(s_detailsPriceLocator, nameof(PriceLabel));
    private IButtonElement BackButton => Factory.CreateElement<IButtonElement>(s_backButtonLocator, nameof(BackButton));
    private ReadOnlyCollection<IButtonElement> AddToCartButton => Factory.CreateElements<IButtonElement>(s_addToCartButtonLocator, nameof(AddToCartButton));
    private IButtonElement RemoveFromCartButton => Factory.CreateElement<IButtonElement>(s_removeFromCartButtonLocator, nameof(RemoveFromCartButton));

    public string ItemName => NameLabel.Text;
    public string ItemDescription => DescriptionLabel.Text;
    public float ItemPrice => Converter.PriceToFloat(PriceLabel.Text);

    public void BackToInventory()
    {
        BackButton.Click();
    }
    
    public void AddToCart()
    {
        AddToCartButton.First().Click();
    }
    
    public void RemoveFromCart()
    {
        RemoveFromCartButton.Click();
    }

    public bool IsInCart
    {
        get
        {
            var inCart = AddToCartButton.Count == 0;
            var message = inCart ? $"{ItemName} is in cart." : $"{ItemName} is not in cart.";
            Logger.Instance.Debug(message);
            
            return inCart;
        }
    }
}