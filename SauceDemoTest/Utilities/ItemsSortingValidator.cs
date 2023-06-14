using SauceDemoTest.Models;

namespace SauceDemoTest.Utilities;

public static class ItemsSortingValidator
{
    public static bool IsSortedAscendingPrice(List<Item> items)
    {
        var ordered = items.OrderBy(item => item.ItemPrice);
        return ordered.SequenceEqual(items);
    }

    public static bool IsSortedDescendingPrice(List<Item> items)
    {
        var ordered = items.OrderByDescending(item => item.ItemPrice);
        return ordered.SequenceEqual(items);
    }

    public static bool IsSortedByName(List<Item> items)
    {
        var ordered = items.OrderBy(item => item.ItemName);
        return ordered.SequenceEqual(items);
    }

    public static bool IsSortedByNameReverse(List<Item> items)
    {
        var ordered = items.OrderByDescending(item => item.ItemName);
        return ordered.SequenceEqual(items);
    }
}