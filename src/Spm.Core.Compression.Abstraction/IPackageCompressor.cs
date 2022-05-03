using Spm.Core.Abstraction;

namespace Spm.Core.Compression.Abstraction;

/// <summary>
/// Provides methods to compress package.
/// </summary>
public interface IPackageCompressor
{
    /// <summary>
    /// Packs directory to package.
    /// </summary>
    /// <param name="source">The directory to pack.</param>
    /// <param name="packageInfo">The package information.</param>
    /// <param name="target">The location to save created package.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The full path to the package.</returns>
    Task<string> Compress(
        string source,
        PackageInfo packageInfo,
        string target = null,
        CancellationToken cancellationToken = default);
}
