namespace SauceDemoTest.Models;

public record class Item(string ItemName, string ItemDescription, float ItemPrice, int ItemQuantity = 1);
