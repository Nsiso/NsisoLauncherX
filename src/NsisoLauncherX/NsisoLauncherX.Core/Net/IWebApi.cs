namespace NsisoLauncherX.Core.Net;

public interface IWebApi
{
    string BaseUrl { get; set; }

    //Task<RequestResult> IsAvailable();
}