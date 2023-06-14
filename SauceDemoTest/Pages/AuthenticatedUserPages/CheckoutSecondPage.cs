using Core.SeleniumWrapper.Elements;
using Core.Utilities;
using OpenQA.Selenium;
using SauceDemoTest.Utilities;

namespace SauceDemoTest.Pages.AuthenticatedUserPages;

public sealed class CheckoutSecondPage : BasePage
{
    public CheckoutSecondPage(string pageName) : base(pageName)
    {
    }
    
    private static readonly By s_subtotalLabelLocator = By.ClassName("summary_subtotal_label");
    private static readonly By s_taxLabelLocator = By.ClassName("summary_tax_label");
    private static readonly By s_totalLabelLocator = By.CssSelector(".summary_info_label.summary_total_label");
    private static readonly By s_cancelButtonLocator = By.Id("cancel");
    private static readonly By s_finishButtonLocator = By.Id("finish");

    private ILabelElement SubtotalLabel => Factory.CreateElement<ILabelElement>(s_subtotalLabelLocator, nameof(SubtotalLabel));
    private ILabelElement TaxLabel => Factory.CreateElement<ILabelElement>(s_taxLabelLocator, nameof(TaxLabel));
    private ILabelElement TotalLabel => Factory.CreateElement<ILabelElement>(s_totalLabelLocator, nameof(TotalLabel));
    private IButtonElement CancelButton => Factory.CreateElement<IButtonElement>(s_cancelButtonLocator, nameof(CancelButton));
    private IButtonElement FinishButton => Factory.CreateElement<IButtonElement>(s_finishButtonLocator, nameof(FinishButton));

    protected override string UrlPath => "/checkout-step-two.html";
    protected override string SubTitle => "Checkout: Overview";

    public float Subtotal
    {
        get
        {
            Logger.Instance.Debug("Getting subtotal of overview");
            var text = SubtotalLabel.Text.Replace("Item total: $", "");
            var subtotal = Converter.PriceToFloat(text);

            return subtotal;
        }
    }
    
    public float Tax
    {
        get
        {
            Logger.Instance.Debug("Getting tax of overview");
            var text = TaxLabel.Text.Replace("Tax: $", "");
            var tax = Converter.PriceToFloat(text);

            return tax;
        }
    }

    public float Total
    {
        get
        {
            Logger.Instance.Debug("Getting total of overview");
            var text = TotalLabel.Text.Replace("Total: $", "");
            var total = Converter.PriceToFloat(text);

            return total;
        }
    }
    
    public void Finish()
    {
        Logger.Instance.Debug("Finishing the checkout.");
        
        FinishButton.Click();
    }

    public void Cancel()
    {
        Logger.Instance.Debug("Canceling the checkout.");
        
        CancelButton.Click();
    }
}