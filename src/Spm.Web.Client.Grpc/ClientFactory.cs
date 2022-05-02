using Grpc.Net.Client;
using Spm.Web.Api;

namespace Spm.Web.Client.Grpc;

public class ClientFactory
{
    public ClientFactory()
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:7042");
        var client = new SpmApi.SpmApiClient(channel);
        // client.PullPackageAsync(new PullPackageRequest()).ResponseAsync.Result.;
    }
}