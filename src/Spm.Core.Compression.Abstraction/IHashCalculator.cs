namespace Spm.Core.Compression.Abstraction;

public interface IHashCalculator
{
    /// <summary>
    /// Calculates package hash.
    /// </summary>
    /// <param name="package">The stream with package to calculate hash.</param>
    /// <returns>The hash.</returns>
    string Calculate(Stream package);

    /// <summary>
    /// Calculates package hash by path to file.
    /// </summary>
    /// <param name="path">The path to file.</param>
    /// <returns></returns>
    string Calculate(string path);
}