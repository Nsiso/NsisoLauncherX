using System.Text.Json;

namespace NsisoLauncherX.Core.Net.Meta;

public class MetaService
{
    public string BaseUrl { get; set; } = "https://launchermeta.mojang.com";

    public async Task<RequestResult<VersionManifestV2>> GetVersionManifestV2(NetRequester requester, CancellationToken cancellation = default)
    {
        string url = BaseUrl + "/mc/game/version_manifest_v2.json";
        try
        {
            HttpResponseMessage jsonRespond = await requester.Client.GetAsync(url, cancellation);
            if (!jsonRespond.IsSuccessStatusCode)
            {
                return new RequestResult<VersionManifestV2>(RequestStatus.Error, jsonRespond.StatusCode,
                    jsonRespond.ReasonPhrase, null);
            }

            string jsonStr = await jsonRespond.Content.ReadAsStringAsync(cancellation);
            VersionManifestV2? manifest = JsonSerializer.Deserialize<VersionManifestV2>(jsonStr);
            return manifest == null ? new RequestResult<VersionManifestV2>(new NullReferenceException("Json serializer deserialize the json into an empty object. (VersionManifestV2)")) : new RequestResult<VersionManifestV2>(RequestStatus.Success, jsonRespond.StatusCode, null, manifest);
        }
        catch (TaskCanceledException e)
        {
            return new RequestResult<VersionManifestV2>(e);
        }
        catch (Exception e)
        {
            return new RequestResult<VersionManifestV2>(e);
        }
        
    }
}