using System.Runtime.InteropServices;

namespace Boop.PInvokes.Memory;

public static class GetPhysicallyInstalledSystemMemoryDef
{
    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetPhysicallyInstalledSystemMemory(out long totalMemoryInKilobytes);

    public static long GetPhysicallyInstalledSystemMemory()
    {
        bool getResul = GetPhysicallyInstalledSystemMemory(out long totalMemoryInKilobytes);
        return getResul ? totalMemoryInKilobytes : -1;
    }
}