using System;
using System.IO.Compression;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Spm.Core.Compression;
using Spm.Core.Compression.Abstraction;
using Xunit;

namespace Spm.Core.Tests.Compression;

public class IocTests
{
    [Fact]
    public void GetZipCompressor_Should_BeSuccess()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddCompressor(configurations =>
        {
            configurations.CompressionLevel = CompressionLevel.Optimal;
            configurations.CompressionAlgorithm = CompressionAlgorithm.Zip;
            configurations.HashAlgorithm = HashAlgorithm.Md5;
        });

        var provider = services.BuildServiceProvider();

        // Act
        var compressor = provider.GetService<IPackageCompressor>();

        // Assert
        compressor.Should().NotBeNull();
    }

    [Fact]
    public void GetUnknownCompressor_Should_ThrowException()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddCompressor(configurations =>
        {
            configurations.CompressionLevel = CompressionLevel.Optimal;
            configurations.CompressionAlgorithm = (CompressionAlgorithm)500;
            configurations.HashAlgorithm = HashAlgorithm.Md5;
        });

        var provider = services.BuildServiceProvider();

        // Act and Assert
        Assert.Throws<ValidationException>(
            () => provider.GetService<IPackageCompressor>()
        );
    }
}
