using System.Security.Cryptography;
using NsisoLauncherX.Core.Net;

namespace NsisoLauncherX.Core.Version;

/// <summary>
/// The basic element for sha1, size and url model
/// </summary>
public class Sha1SizeUrl : IDownloadableFile
{
    /// <summary>
    /// SHA1
    /// </summary>
    public string Sha1 { get; set; }

    /// <summary>
    /// 文件大小
    /// </summary>
    public ulong Size { get; set; }

    /// <summary>
    /// 下载URL
    /// </summary>
    public string Url { get; set; }

    // implement for IDownloadableFile interface
    public string DownloadSourceUrl => Url;
    public ulong? TotalSize => Size;
    public Tuple<HashAlgorithmName, string>? HashNameValue => new(HashAlgorithmName.SHA1, Sha1);
}

/// <summary>
/// The basic element for path, sha1, size and url model
/// </summary>
public class PathSha1SizeUrl : Sha1SizeUrl
{
    /// <summary>
    /// The file path
    /// </summary>
    public string Path { get; set; }
}