using System.Text.Json;

namespace Boop.Services;

using System.Collections.Generic;

public class ThemeService : IDisposable
{
    private static ThemeService? _instance;
    public static ThemeService Instance => _instance ??= new ThemeService();
    
    private const string StylesPath = "styles.json";
    private const string DefaultStyle = "white bold";
    private readonly Dictionary<string, string>? _styles;

    private ThemeService()
    {
        if (!File.Exists(StylesPath))
        {
            _styles = new();
            SaveStyles();
        }
        
        string stylesJson = File.ReadAllText(StylesPath);
        _styles = JsonSerializer.Deserialize<Dictionary<string, string>>(stylesJson);
    }

    public string GetStyle(string key) => _styles?.GetValueOrDefault(key, DefaultStyle) ?? DefaultStyle;
    
    private void SaveStyles()
    {
        string stylesJson = JsonSerializer.Serialize(_styles);
        File.WriteAllText(StylesPath, stylesJson);
    }
    
    public void Dispose()
    {
        SaveStyles();
    }
}
