using Boop.Panels.Top;

HardwareUsage.AddHardwareInfo("CPU", 12);
HardwareUsage.AddHardwareInfo("RAM", 50);
HardwareUsage.AddHardwareInfo("Network", 80);



AnsiConsole.Write(HardwareUsage.CreateHardwareInfoPanel(""));