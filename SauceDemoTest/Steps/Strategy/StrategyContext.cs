using Core.Utilities;

namespace SauceDemoTest.Steps.Strategy;

public class StrategyContext
{
    private IStrategy _strategy;

    public StrategyContext()
    {
    }
    
    public StrategyContext(IStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void RemoveFromCart(int index)
    {
        Logger.Instance.Debug($"Removing {index} item.");

        _strategy.RemoveFromCart(index);
    }
    
    public void RemoveFromCart(string name)
    {
        Logger.Instance.Debug($"Removing {name} item.");

        _strategy.RemoveFromCart(name);
    }
    
    public void AddToCart(int index)
    {
        Logger.Instance.Debug($"Adding {index} item.");

        _strategy.AddToCart(index);
    }
    
    public void AddToCart(string name)
    {
        Logger.Instance.Debug($"Adding {name} item.");

        _strategy.AddToCart(name);
    }
}