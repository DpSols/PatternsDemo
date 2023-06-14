using OpenQA.Selenium;

namespace Core.SeleniumWrapper.Elements.ConcreteElements;

internal sealed class LabelElement : BaseElement, ILabelElement
{
    public LabelElement(IWebElement element, string name) : base(element, name)
    {
    }
}