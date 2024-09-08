namespace Boop.Types.Attributes;

public class DisplayNameAttribute(string displayName) : Attribute
{
    public string DisplayName { get; } = displayName;
}