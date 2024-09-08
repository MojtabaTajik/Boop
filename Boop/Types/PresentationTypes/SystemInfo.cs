namespace Boop.Types.PresentationTypes;

public class SystemInfo
{
    public string MachineName { get; init; }
    public string CPUModel { get; init; }
    public string CPUCoreCount { get; init; }
    public string OSVersion { get; init; }
    public string TotalMemory { get; init; }
    public string SystemArchitecture { get; init; }
}