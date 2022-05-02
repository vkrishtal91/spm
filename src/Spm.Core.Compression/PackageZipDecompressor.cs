using Spm.Core.Abstraction;
using Spm.Core.Compression.Abstraction;

namespace Spm.Core.Compression;

internal class PackageZipDecompressor : IPackageDecompressor
{
    public Task<string> Decompress(string package, string location = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<string> Decompress(Stream package, string location, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PackageInfo> ReadMeta(Stream package, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}