using Boop.PInvokes.Memory;
using Boop.Types;
using Microsoft.Win32;

namespace Boop.Services;

public class SystemInfoService
{
    private static SystemInfoService? _instance;

    public static SystemInfoService Instance => _instance ??= new SystemInfoService();

    public SystemInfo HardwareInfo { get; }

    private SystemInfoService()
    {
        HardwareInfo = new SystemInfo
        {
            MachineName = Environment.MachineName,
            CPUModel = GetCpuModel(),
            CPUCoreCount = Environment.ProcessorCount.ToString(),
            OSVersion = Environment.OSVersion.VersionString,
            TotalMemory = GetTotalMemory(),
            SystemArchitecture = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit"
        };
    }
    
    private string GetCpuModel()
    {
        using RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
        return key?.GetValue("ProcessorNameString")?.ToString() ?? "Unknown";
    }
    
    private string GetTotalMemory()
    {
        const int kbToGbConversionRate = 1024 * 1024;
        
        double totalMemory = GetPhysicallyInstalledSystemMemoryDef.GetPhysicallyInstalledSystemMemory();
        return $"{totalMemory/kbToGbConversionRate:F1} GB";
    }
}