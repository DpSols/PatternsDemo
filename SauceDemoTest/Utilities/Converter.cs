using System.Globalization;
using Core.Utilities;

namespace SauceDemoTest.Utilities;

public static class Converter
{
    public static float PriceToFloat(string text)
    {
        NumberStyles styles = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
        
        if(!float.TryParse(text.Trim(), styles, culture, out float price))
        {
            Logger.Instance.Error("Price was not in expected format!");
            return float.NaN;
        }
        
        return price;
    }
}