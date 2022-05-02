using Grpc.Core;
using Spm.Web.Api;

namespace Spm.Web.Api.Services;

public class SpmApiService : SpmApi.SpmApiBase
{
    private readonly ILogger<SpmApiService> _logger;

    public SpmApiService(ILogger<SpmApiService> logger)
    {
        _logger = logger;
    }

    public override Task<PullPackageResponse> PullPackage(PullPackageRequest request, ServerCallContext context)
    {
        return base.PullPackage(request, context);
    }

    public override Task<PushPackageResponse> PushPackage(PushPackageRequest request, ServerCallContext context)
    {
        return base.PushPackage(request, context);
    }

    public override Task<DeletePackageResponse> DeletePackage(DeletePackageRequest request, ServerCallContext context)
    {
        return base.DeletePackage(request, context);
    }

    public override Task<GetPackageResponse> GetPackages(GetPackagesRequest request, ServerCallContext context)
    {
        return base.GetPackages(request, context);
    }
}