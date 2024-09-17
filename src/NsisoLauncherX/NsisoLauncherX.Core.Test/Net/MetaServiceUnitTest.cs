using NsisoLauncherX.Core.Net;
using NsisoLauncherX.Core.Net.Meta;

namespace NsisoLauncherX.Core.Test.Net;

public class MetaServiceUnitTest
{
    public MetaService  Service { get; set; }
    public NetRequester Requester { get; set; }
    [SetUp]
    public void Setup()
    {
        this.Service = new MetaService();
        this.Requester = new NetRequester();
    }

    [Test]
    public async Task TestVersionManifest()
    {
        var result = await this.Service.GetVersionManifestV2(this.Requester);
        if (result.IsSuccess)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }
}