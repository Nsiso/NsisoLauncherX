using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace NsisoLauncherX.Core.Utils;

public static class SystemTools
{
    public static bool IsOsPlatform(string platform)
    {
        return OperatingSystem.IsOSPlatform(platform);
    }
    
    public static bool IsProcessArchitecture(string arch)
    {
        var realArch = GetProcessArchitecture();
        switch (realArch)
        {
            case Architecture.X86:
                if (arch == "x86")
                    return true;
                break;
            case Architecture.X64:
                if (arch == "x64")
                    return true;
                break;
            case Architecture.Arm:
                if (arch == "arm")
                    return true;
                break;
            case Architecture.Arm64:
                if (arch == "arm64")
                    return true;
                break;
            case Architecture.Wasm:
                if (arch == "wasm")
                    return true;
                break;
            case Architecture.S390x:
                if (arch == "s390x")
                    return true;
                break;
            case Architecture.LoongArch64:
                if (arch == "loong64")
                    return true;
                break;
            case Architecture.Armv6:
                if (arch == "armv6")
                    return true;
                break;
            case Architecture.Ppc64le:
                if (arch == "ppc64le")
                    return true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return false;
    }

    public static bool IsOsVersionRegex(string osVersion)
    {
        return Regex.Match(GetOSVersion(), osVersion).Success;
    }

    public static Architecture GetProcessArchitecture()
    {
        return RuntimeInformation.ProcessArchitecture;
    }
    
    public static string GetOSVersion()
    {
        return Environment.OSVersion.Version.ToString();
    }
}