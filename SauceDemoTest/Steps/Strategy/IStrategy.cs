namespace SauceDemoTest.Steps.Strategy;

public interface IStrategy
{
    public void RemoveFromCart(int index);
    public void RemoveFromCart(string name);
    public void AddToCart(int index);
    public void AddToCart(string name);
}