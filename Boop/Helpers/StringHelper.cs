using Boop.Services;

namespace Boop.Helpers;

public static class StringHelper
{
    public static string ApplyStyle(this string text, string propertyName)
    {
        var style = ThemeService.Instance.GetStyle(propertyName);
        return $"[{style}]{text}[/]";
    }
}