namespace Core.SeleniumWrapper.Elements
{
    public interface IInputElement : IBaseElement
    {
        void Clear();
        void Input(string text);
    }
}