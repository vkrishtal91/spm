using System.IO.Compression;
using Spm.Core.Abstraction;

namespace Spm.Core.Compression.Abstraction;

/// <summary>
/// Represents a manifest inside the package to get all required information about the package.
/// </summary>
public sealed class PackageManifest
{
    /// <summary>
    /// The package unique name. 
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The package semantic version.
    /// </summary>
    public Version Version { get; set; }

    /// <summary>
    /// The package description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The package labels.
    /// </summary>
    public IEnumerable<string> Labels { get; set; }

    /// <summary>
    /// The additional information about the package.
    /// </summary>
    public IReadOnlyDictionary<string, string> Tags { get; set; }

    /// <summary>
    /// The common content hash.
    /// </summary>
    public string ContentHash { get; set; }

    /// <summary>
    /// The common content size in bytes.
    /// </summary>
    public long ContentSize { get; set; }

    /// <summary>
    /// The date when package was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// The machine name which was used to create the package.
    /// </summary>
    public string CreatedOnMachine { get; set; }

    /// <summary>
    /// The username who created the package.
    /// </summary>
    public string CreatedByUser { get; set; }

    /// <summary>
    /// The operating system used on computer ro create the package.
    /// </summary>
    public string CreatedOnSystem { get; set; }
}

public interface IPackageManifestReader
{
    Task<PackageManifest> Read(string path, CancellationToken cancellationToken = default);
    Task<PackageManifest> Read(Stream stream, CancellationToken cancellationToken = default);
}

public interface IPackageManifestWriter
{
    Task Write(PackageManifest manifest, string path, CancellationToken cancellationToken = default);
    Task Write(PackageManifest manifest, Stream stream, CancellationToken cancellationToken = default);
}

public sealed class Package
{
    public PackageManifest Manifest { get; set; }
    public string Location { get; set; }
    public Int64 PackageSize { get; set; }
    public string PackageHash { get; set; }
}

public interface IPackageReader
{
    Task<Package> Unpack(string package, string destination, CancellationToken cancellationToken = default);
    Task<Package> Unpack(Stream stream, string destination, CancellationToken cancellationToken = default);
}

public interface IPackageWriter
{
    Task<Package> Create(string source, PackageInfo packageInfo, CancellationToken cancellationToken = default);
}
