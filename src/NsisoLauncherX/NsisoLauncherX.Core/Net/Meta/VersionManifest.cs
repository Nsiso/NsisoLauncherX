using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NsisoLauncherX.Core.Net.Meta;

[DebuggerDisplay("VersionManifest count={Versions?.Count}")]
public class VersionManifest<TContent> where TContent : VersionMeta
{
    [JsonPropertyName("latest")]
    public VersionLatest? Latest { get; set; }

    [JsonPropertyName("versions")]
    public List<TContent>? Versions { get; set; }
}

[DebuggerDisplay("{Id}")]
public class VersionMetaV2 : VersionMeta
{
    /// <summary>
    /// The sha1 hash of the version (like id)
    /// </summary>
    [JsonPropertyName("sha1")]
    public string Sha1 { get; set; }

    /// <summary>
    /// The compliance level of the version
    /// If 0, the launcher warns the user about this version not being recent enough to support the latest player safety features. Its value is 1 otherwise.
    /// </summary>
    [JsonPropertyName("complianceLevel")]
    public int ComplianceLevel { get; set; }
}

[DebuggerDisplay("{Id}")]
public class VersionMeta
{
    /// <summary>
    /// 版本ID
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// 版本类型
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// 版本修改时间
    /// </summary>
    [JsonPropertyName("time")]
    public string Time { get; set; }

    /// <summary>
    /// 版本发布时间
    /// </summary>
    [JsonPropertyName("releaseTime")]
    public string ReleaseTime { get; set; }

    /// <summary>
    /// 版本下载URL
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class VersionLatest
{
    [JsonPropertyName("release")]
    public string Release { get; set; }

    [JsonPropertyName("snapshot")]
    public string Snapshot { get; set; }
}