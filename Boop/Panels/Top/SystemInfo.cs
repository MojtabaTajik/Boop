namespace Boop.Panels.Top;

public static class SystemInfo
{
    public static Panel CreateSystemInfoPanel(string title, Types.PresentationTypes.SystemInfo systemInfo)
    {
        var grid = new Grid()
            .AddColumn(new GridColumn().NoWrap().PadRight(4))
            .AddColumn()
            .AddColumn()
            .AddColumn()
            .AddRow("[b]CPU Model[/]", systemInfo.CPUModel, "[b]CPU Core[/]", systemInfo.CPUCoreCount)
            .AddRow("[b]OS Version[/]", systemInfo.OSVersion, "[b]OS Architecture[/]", systemInfo.SystemArchitecture)
            .AddRow("[b]Total Memory[/]", $"{systemInfo.TotalMemory}");
        
        return new Panel(grid)
            .Header(title)
            .Expand()  
            .Border(BoxBorder.Square);
    }
}