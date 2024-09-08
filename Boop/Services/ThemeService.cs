namespace Boop.Services;

using System.Collections.Generic;

public static class ThemeService
{
    private static Dictionary<string, string> Styles { get; } = new()
    {
        { "OSVersion", "red bold" },
        { "TotalMemory", "green italic" },
        // Add other object names and their corresponding styles here
    };

    public static string GetStyle(string key)
    {
        return Styles.TryGetValue(key, out var style) ? style : "white bold";
    }
}
