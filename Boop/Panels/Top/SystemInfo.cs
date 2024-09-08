using Boop.Helpers;

namespace Boop.Panels.Top;

public static class SystemInfo
{
    public static Panel CreateSystemInfoPanel(Types.PresentationTypes.SystemInfo systemInfo)
    {
        var grid = new Grid()
            .AddColumn(new GridColumn().NoWrap().PadRight(4))
            .AddColumn()
            .AddColumn()
            .AddColumn();


        var properties = typeof(Types.PresentationTypes.SystemInfo).GetProperties();

        foreach (var property in properties)
        {
            var displayName = Types.PresentationTypes.SystemInfo.GetDisplayName(property.Name);
            string displayValue = property.GetValue(systemInfo)?.ToString() ?? "N/A";
            
            grid.AddRow(displayName.ApplyStyle(property.Name), displayValue.ApplyStyle(property.Name));
        }

        string machineUser = $"{systemInfo.MachineName} - {systemInfo.UserName}";
        return new Panel(grid)
            .Header(machineUser)
            .Expand()
            .Border(BoxBorder.Square);
    }
}