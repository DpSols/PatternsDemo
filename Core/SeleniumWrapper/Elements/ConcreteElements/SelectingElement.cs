using Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.SeleniumWrapper.Elements.ConcreteElements;

internal sealed class SelectingElement : BaseElement, ISelectingElement
{
    private readonly SelectElement _selectElement;
    public SelectingElement(IWebElement element, string name) : base(element, name)
    {
        _selectElement = new SelectElement(Element);
    }

    public void SelectByValue(string value)
    {
        Logger.Instance.Debug($"Selecting value: {value}");
        _selectElement.SelectByValue(value);
    }
    
    public string[] AllSelectedValues => _selectElement.AllSelectedOptions.Select(element => element.GetAttribute("value")).ToArray();
}