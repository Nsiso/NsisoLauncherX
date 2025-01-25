namespace NsisoLauncherX.Core.Version;

/// <summary>
/// All version file's shared info
/// </summary>
public class VersionShare
{
    /// <summary>
    /// asset file index info
    /// </summary>
    public AssetIndex AssetIndex { get; set; }

    /// <summary>
    /// using assets id
    /// </summary>
    public string Assets { get; set; }

    /// <summary>
    /// Compliance level (for safe check)
    /// </summary>
    public string ComplianceLevel { get; set; }

    /// <summary>
    /// version core jar download info
    /// </summary>
    public CoreDownloads Downloads { get; set; }

    /// <summary>
    /// the id of this version
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// This version inherits from (depends on) the given version, normally appears in the mod version like forge.
    /// Normally this would not be a recursion
    /// </summary>
    public string? InheritsFrom { get; set; }

    /// <summary>
    /// The version using java version info
    /// </summary>
    public JavaDependent JavaVersion { get; set; }

    /// <summary>
    /// Giving launch main class in jar
    /// </summary>
    public string MainClass { get; set; }

    /// <summary>
    /// The target jar file, only appear in other non-official version.
    /// </summary>
    public string? Jar { get; set; }

    /// <summary>
    /// All the dependent libraries (artifact and classifier)
    /// </summary>
    public List<Library> Libraries { get; set; }

    /// <summary>
    /// This minimum launcher version can success launch this game. 
    /// </summary>
    public int MinimumLauncherVersion { get; set; }

    /// <summary>
    /// Last update time
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// Release time
    /// </summary>
    public DateTime ReleaseTime { get; set; }

    /// <summary>
    /// This version's type (like 'release' or 'snapshot'...)
    /// </summary>
    public string Type { get; set; }
}

public class AssetIndex : Sha1SizeUrl
{
    /// <summary>
    /// Asset ID
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Total size of all the assets file.
    /// </summary>
    public long TotalSize { get; set; }
}

public class CoreDownloads
{
    /// <summary>
    /// Client core download info
    /// </summary>
    public Sha1SizeUrl Client { get; set; }

    /// <summary>
    /// Server core download info
    /// </summary>
    public Sha1SizeUrl Server { get; set; }

    /// <summary>
    /// client mapping download info
    /// </summary>
    public Sha1SizeUrl ClientMappings { get; set; }
}

public class JavaDependent
{
    /// <summary>
    /// The java's nick name like 'jre-legacy'
    /// </summary>
    public string Component { get; set; }
    
    /// <summary>
    /// The major version of this java like 8
    /// </summary>
    public int MajorVersion { get; set; }
}