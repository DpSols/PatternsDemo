namespace Core.SeleniumWrapper.Elements
{
    public interface ISelectingElement : IBaseElement
    {
        public string[] AllSelectedValues { get; }

        void SelectByValue(string value);
    }
}