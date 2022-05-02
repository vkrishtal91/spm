namespace Spm.Web.Client.Abstraction;

/// <summary>
/// Represents a request body to download package to specify directory.
/// </summary>
/// <param name="Id">The identifier to download the package.</param>
/// <param name="SaveTo">The directory to save the package.</param>
public sealed record PullPackageRequest(PackageId Id, string SaveTo);

public sealed record PushPackageRequest(string package);