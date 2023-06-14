using System.Drawing;
using Core.Utilities;
using OpenQA.Selenium;

namespace Core.SeleniumWrapper.Elements.ConcreteElements;

internal abstract class BaseElement : IBaseElement
{
    protected IWebElement Element { get; }
    public string Name { get; }

    protected BaseElement(IWebElement element, string name)
    {
        Element = element;
        Name = name;
    }

    public string Text
    { 
        get
        {
            string text = Element.Text;
            Logger.Instance.Debug($"Getting text of element {Name} ({text}).");
            
            return text;
        }
    }
    
    public bool Displayed
    {
        get
        {
            bool displayed = Element.Displayed;
            string message = displayed ? "displayed" : "not displayed";
            Logger.Instance.Debug($"Element {Name} is {message}.");
            
            return displayed;
        }
    }

    public string GetAttribute(string attributeName)
    {
        var attribute = Element.GetAttribute(attributeName);
        Logger.Instance.Debug($"Getting {attributeName} attribute of element: {Name} ({attribute}).");
        
        return Element.GetAttribute(attributeName);
    }

    public Point Location
    {
        get
        {
            Point location = Element.Location;
            Logger.Instance.Debug($"Getting location of element: {Name} ({location})");
            
            return location;
        }
    }

    public override string ToString()
    {
        return Name;
    }
}