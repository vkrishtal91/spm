namespace Spm.Web.Abstraction;

public interface ISpmClient
{
    Task<PullPackageWebResponse> PullPackage(PullPackageRequest request, CancellationToken cancellationToken = default);
    Task<PushPackageResponse> PushPackage(PushPackageRequest request, CancellationToken cancellationToken = default);
    Task<DeletePackageResponse> DeletePackage(DeletePackageRequest request, CancellationToken cancellationToken = default);
    Task<GetPackageResponse> GetPackages(GetPackagesRequest request, CancellationToken cancellationToken = default);
}