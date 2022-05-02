namespace Spm.Web.Client.Abstraction;

/// <summary>
/// Represents identifier for package.
/// </summary>
/// <param name="Name">The package name.</param>
/// <param name="Version">The project version.</param>
public sealed record PackageId(string Name, Version Version);

/// <summary>
/// Represents the package meta information.
/// </summary>
/// <param name="Id">The package identifier.</param>
/// <param name="Hash">The package content hash.</param>
public sealed record PackageInfo(PackageId Id, string Hash)
{
    /// <summary>
    /// The package description
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// The package labels
    /// </summary>
    public IEnumerable<string> Labels { get; init; }

    /// <summary>
    /// The additional information about the package
    /// </summary>
    public IReadOnlyDictionary<string, string> Tags { get; init; }
}