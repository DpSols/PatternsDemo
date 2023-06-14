using OpenQA.Selenium;

namespace Core.SeleniumWrapper.Elements.ConcreteElements;

internal sealed class CheckboxElement : BaseElement, ICheckboxElement
{
    public CheckboxElement(IWebElement element, string name) : base(element, name)
    {
    }

    public bool IsSelected => Element.Selected;
}
