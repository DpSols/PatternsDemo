using Core.Utilities;
using OpenQA.Selenium;

namespace Core.SeleniumWrapper.Elements.ConcreteElements;

internal sealed class LinkElement : BaseElement, ILinkElement
{
    public LinkElement(IWebElement element, string name) : base(element, name)
    {
    }

    public void Click()
    {
        Logger.Instance.Debug($"Clicking on {Name} Link.");
        Element.Click();
    }
}