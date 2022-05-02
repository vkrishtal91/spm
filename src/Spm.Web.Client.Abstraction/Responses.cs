namespace Spm.Web.Client.Abstraction;

/// <summary>
/// Represents a response body that contains information about downloaded package.
/// </summary>
/// <param name="PackageInfo">The information about downloaded package.</param>
/// <param name="FileInfo">The information about downloaded file.</param>
public sealed record PullPackageResponse(PackageInfo PackageInfo, FileInfo FileInfo);

