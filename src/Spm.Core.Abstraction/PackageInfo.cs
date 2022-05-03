namespace Spm.Core.Abstraction;

/// <summary>
/// Represents the package meta information.
/// </summary>
/// <param name="Id">The package identifier.</param>
/// <param name="Hash">The package content hash.</param>
public sealed record PackageInfo(PackageId Id, string Hash)
{
    /// <summary>
    /// The package description.
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// The package labels.
    /// </summary>
    public IEnumerable<string> Labels { get; init; }

    /// <summary>
    /// The additional information about the package.
    /// </summary>
    public IReadOnlyDictionary<string, string> Tags { get; init; }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"{Id}.sp";
    }
}

public sealed record PackageManifest(PackageInfo PackageInfo, string ContentHash);
