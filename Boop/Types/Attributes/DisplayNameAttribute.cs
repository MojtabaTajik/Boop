namespace Boop.Types.Attributes;

public class DisplayNameAttribute(string displayName, bool autoRender = true) : Attribute
{
    public string DisplayName { get; } = displayName;
    public bool AutoRender { get; } = autoRender;
}