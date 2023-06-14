using System.Drawing;

namespace Core.SeleniumWrapper.Elements
{
    public interface IBaseElement
    {
        string Name { get; }
        string GetAttribute(string attributeName);
        Point Location { get; }
        string Text { get; }
        bool Displayed { get; }
        string ToString();
    }
}