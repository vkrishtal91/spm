using System.Security.Cryptography;
using Spm.Core.Compression.Abstraction;

namespace Spm.Core.Compression;

/// <summary>
/// Represents a simple hash calculator.
/// </summary>
internal sealed class PackageMd5Calculator : IHashCalculator
{
    /// <summary>
    /// Calculates package hash.
    /// </summary>
    /// <param name="package">The stream with package to calculate hash.</param>
    /// <returns>The hash.</returns>
    public string Calculate(Stream package)
    {
        package.Seek(0, SeekOrigin.Begin);
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(package);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }

    /// <summary>
    /// Calculates package hash by path to file.
    /// </summary>
    /// <param name="path">The path to file.</param>
    /// <returns></returns>
    public string Calculate(string path)
    {
        using var stream = File.OpenRead(path);
        return Calculate(stream);
    }
}