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
    public async Task TestVersionManifestV2()
    {
        var result = await this.Service.GetVersionManifestV2(this.Requester);
        if (result is { IsSuccess: true, Content: not null })
            Assert.Pass();
        else
            Assert.Fail();
    }
    
    [Test]
    [Obsolete("Obsolete, test for compatibility use.")]
    public async Task TestVersionManifestV1()
    {
        var result = await this.Service.GetVersionManifestV1(this.Requester);
        if (result is { IsSuccess: true, Content: not null })
            Assert.Pass();
        else
            Assert.Fail();
    }
}