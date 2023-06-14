using Core.Utilities;
using OpenQA.Selenium;

namespace Core.SeleniumWrapper.Elements.ConcreteElements;

internal sealed class ButtonElement : BaseElement, IButtonElement
{
    internal ButtonElement(IWebElement element, string name) : base(element, name)
    {
    }

    public void Click()
    {
        Logger.Instance.Debug($"Clicking on {Name} Button.");
        Element.Click();
    }
}