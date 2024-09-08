namespace Boop.Panels.Top;

public static class HardwareUsage
{
    private static readonly List<BarChartItem> Items = new();

    public static void AddHardwareInfo(string title, int value)
    {
        var color = value switch
        {
            < 50 => Color.Green,
            < 80 => Color.Yellow,
            _ => Color.Red
        };

        Items.Add(new BarChartItem(title, value, color));
    }

    public static Panel CreateHardwareInfoPanel(string title)
    {
        var chart = new BarChart()
            .AddItems(Items)
            .WithMaxValue(100)
            .UseValueFormatter(HardwareUsageValueFormatter());

        return new Panel(chart)
            .Header(title)
            .Expand();
    }

    private static Func<double, string> HardwareUsageValueFormatter() => value => $"{value}%";
}