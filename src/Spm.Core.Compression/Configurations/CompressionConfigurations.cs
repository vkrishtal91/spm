using System.IO.Compression;
using Spm.Core.Compression.Abstraction;

namespace Spm.Core.Compression.Configurations;

public sealed class CompressionConfigurations
{
    public CompressionLevel CompressionLevel { get; set; } = CompressionLevel.Optimal;
    public CompressionAlgorithm CompressionAlgorithm { get; set; } = CompressionAlgorithm.Zip;
    public HashAlgorithm HashAlgorithm { get; set; } = HashAlgorithm.Md5;
}