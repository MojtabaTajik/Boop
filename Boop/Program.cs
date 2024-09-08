using Boop.Panels.Top;
using Boop.Services;

HardwareUsage.AddHardwareInfo("CPU", 12);
HardwareUsage.AddHardwareInfo("RAM", 50);
HardwareUsage.AddHardwareInfo("Network", 80);


AnsiConsole.Write(SystemInfo.CreateSystemInfoPanel(SystemInfoService.Instance.HardwareInfo));
AnsiConsole.Write(HardwareUsage.CreateHardwareInfoPanel(""));