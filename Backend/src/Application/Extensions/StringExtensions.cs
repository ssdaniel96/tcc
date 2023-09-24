using System.Text.RegularExpressions;

namespace Application.Extensions;

public static class StringExtensions
{
    public static string GetOnlyAlfaNumerics(this string? sentence)
    {
        var newValue = string.Empty;

        if (sentence == null)
            return newValue;

        foreach (var c in sentence)
        {
            if (c.IsAlfaNumeric())
            {
                newValue += c;
            }
        }

        return newValue;
    }

    public static bool IsAlfaNumeric(this char character)
    {
        var alfanumericGroup = new Regex("[a-zA-Z0-9]");

        return alfanumericGroup.IsMatch(character.ToString());
    }
}