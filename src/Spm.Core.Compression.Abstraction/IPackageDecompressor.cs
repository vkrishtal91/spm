using Spm.Core.Abstraction;

namespace Spm.Core.Compression.Abstraction;

/// <summary>
/// Provides methods to decompress packages.
/// </summary>
public interface IPackageDecompressor
{
    /// <summary>
    /// Unpacks the packages to specify location or near the package.
    /// </summary>
    /// <param name="package">The package to unpack.</param>
    /// <param name="location">The location to save files from package.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The installation directory.</returns>
    Task<string> Decompress(string package,
        string location = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Unpacks the packages to specify location.
    /// </summary>
    /// <param name="package">The package to unpack.</param>
    /// <param name="location">The location to save files from package.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The installation directory.</returns>
    Task<string> Decompress(Stream package,
        string location,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns meta information about package.
    /// </summary>
    /// <param name="package">The stream with package.</param>
    /// <returns>The package meta information.</returns>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<PackageInfo> ReadMeta(Stream package, CancellationToken cancellationToken = default);
}