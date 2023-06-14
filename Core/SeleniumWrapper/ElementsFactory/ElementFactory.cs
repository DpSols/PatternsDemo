using System.Collections.ObjectModel;
using Core.SeleniumWrapper.Elements;
using Core.SeleniumWrapper.Elements.ConcreteElements;
using Core.Utilities;
using OpenQA.Selenium;

namespace Core.SeleniumWrapper.ElementsFactory;

public class ElementFactory
{
    private readonly Dictionary<Type, Func<IWebElement, string, IBaseElement>> _elementCreators;
    private WebDriver Driver { get; }

    public ElementFactory(WebDriver driver)
    {
        Logger.Instance.Debug("Element Factory created!");
        
        _elementCreators = new Dictionary<Type, Func<IWebElement, string, IBaseElement>>()
        {
            { typeof(IButtonElement), (element, elementName) => new ButtonElement(element, elementName) },
            { typeof(ISelectingElement), (element, elementName) => new SelectingElement(element, elementName) },
            { typeof(ILinkElement), (element, elementName) => new LinkElement(element, elementName) },
            { typeof(ILabelElement), (element, elementName) => new LabelElement(element, elementName) },
            { typeof(IInputElement), (element, elementName) => new InputElement(element, elementName) },
            { typeof(ICheckboxElement), (element, elementName) => new CheckboxElement(element, elementName) }
        };
        
        Driver = driver;
    }

    public bool IsDisposed => Driver.SessionId is null;
    
    private T CreateElementWithWebElement<T>(IWebElement webElement, string name) where T : IBaseElement
    {
        if (!_elementCreators.TryGetValue(typeof(T), out Func<IWebElement, string, IBaseElement> concreteElement))
        {
            throw new ArgumentException($"There is no element of {typeof(T)}.");
        }

        return (T)concreteElement(webElement, name);
    }

    public T CreateElement<T>(By locator, string name) where T : IBaseElement
    {

        IWebElement webElement;

        try
        {
            webElement = Driver.FindElement(locator);
        }
        catch (Exception e)
        {
            Logger.Instance.Error($"Cannot create web element with locator {locator}: {e}.");
            throw;
        }

        return CreateElementWithWebElement<T>(webElement, name);
    }

    public ReadOnlyCollection<T> CreateElements<T>(By locator, string name) where T : IBaseElement
    {
        ReadOnlyCollection<IWebElement> webElements = Driver.FindElements(locator);
        return new ReadOnlyCollection<T>(webElements.Select(element => CreateElementWithWebElement<T>(element, name)).ToList());
    }
}