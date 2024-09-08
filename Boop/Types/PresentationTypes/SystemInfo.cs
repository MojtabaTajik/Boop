using Boop.Types.Attributes;

namespace Boop.Types.PresentationTypes;

public record SystemInfo
{
    [DisplayName("Machine Name")]
    public string MachineName { get; init; }
    [DisplayName("User Name")]
    public string UserName { get; init; }
    [DisplayName("CPU Model")]
    public string CPUModel { get; init; }
    [DisplayName("OS Version")]
    public string OSVersion { get; init; }
    [DisplayName("Total Memory")]
    public string TotalMemory { get; init; }
    [DisplayName("System Architecture")]
    public string SystemArchitecture { get; init; }
    
    public static string GetDisplayName(string propertyName)
    {
        var property = typeof(SystemInfo).GetProperty(propertyName);
        DisplayNameAttribute? displayNameAttribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), false)
            .FirstOrDefault() as DisplayNameAttribute;

        return displayNameAttribute?.DisplayName ?? property.Name;
    }
}