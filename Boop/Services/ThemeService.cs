using System.Text.Json;

namespace Boop.Services;

using System.Collections.Generic;

public class ThemeService : IDisposable
{
    public static ThemeService Instance => _instance ??= new ThemeService();
    
    private static ThemeService? _instance;
    private const string StylesPath = "styles.json";
    private const string DefaultStyle = "white bold";
    private Dictionary<string, string>? _styles;

    private ThemeService()
    {
        if (!File.Exists(StylesPath))
        {
            GenerateDefaultStyle();
            SaveStyles();
        }
        
        string stylesJson = File.ReadAllText(StylesPath);
        _styles = JsonSerializer.Deserialize<Dictionary<string, string>>(stylesJson);
    }

    public string GetStyle(string key) => _styles?.GetValueOrDefault(key, DefaultStyle) ?? DefaultStyle;

    private void GenerateDefaultStyle()
    {
        _styles ??= new Dictionary<string, string>();
        _styles.Add("CPUModel", "blue bold");
        _styles.Add("OSVersion", "green bold");
        _styles.Add("TotalMemory", "red bold");
        _styles.Add("SystemArchitecture", "yellow bold");
    }
    
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
