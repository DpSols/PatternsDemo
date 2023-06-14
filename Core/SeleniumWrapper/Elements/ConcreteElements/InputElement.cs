using Core.Utilities;
using OpenQA.Selenium;

namespace Core.SeleniumWrapper.Elements.ConcreteElements;

internal sealed class InputElement : BaseElement, IInputElement
{
    public InputElement(IWebElement element, string name) : base(element, name)
    {
    }

    public void Input(string text)
    {
        Logger.Instance.Debug($"Sending {text} to input.");
        Element.SendKeys(text);
    }

    public void Clear()
    {
        Logger.Instance.Debug($"Clearing input field.");
        Element.Clear();
    }
}