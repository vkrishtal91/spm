﻿using System.IO.Compression;
using Spm.Core.Abstraction;
using Spm.Core.Compression.Abstraction;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Spm.Core.Compression.Configurations;

namespace Spm.Core.Compression;

/// <summary>
/// Represents 
/// </summary>
internal class PackageZipCompressor : IPackageCompressor
{
    // the json serialization options
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true,
        Converters = {new JsonStringEnumConverter()}
    };

    // the package validator
    private readonly IPackageInfoValidator _validator;
    private readonly IOptions<CompressionConfigurations> _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="PackageZipCompressor" /> class.
    /// </summary>
    public PackageZipCompressor(IPackageInfoValidator validator, IOptions<CompressionConfigurations> config)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    /// <summary>
    /// Packs the directory to package.
    /// </summary>
    /// <param name="source">The directory to pack.</param>
    /// <param name="packageInfo">The package information to use to pack.</param>
    /// <param name="target">The location to save created package.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public async Task<string> Compress(
        string source,
        PackageInfo packageInfo,
        string target = null,
        CancellationToken cancellationToken = default)
    {
        if (!Directory.Exists(source))
        {
            throw new DirectoryNotFoundException("The directory to pack was not found");
        }

        // validate packageInfo information
        await _validator.Validate(packageInfo, cancellationToken);

        // determine file to future package
        // the user specified path can be null
        // and we use the name of source directory to name package in this case
        var package = string.IsNullOrWhiteSpace(target)
            ? $"{Path.GetDirectoryName(source)}/{packageInfo.GetFileName()}"
            : $"{target}/{packageInfo.GetFileName()}";

        // determine path to temp packageInfo file (dont forget to delete it after pack)
        var packageInfoFile = $"{source}/{Configs.packageInfoFileName}";

        // create package
        await Pack(source, packageInfo, packageInfoFile, package, cancellationToken);
        return Path.GetFullPath(package);
    }

    /// <summary>
    /// Packs the directory as package.
    /// </summary>
    private async Task Pack(
        string source,
        PackageInfo packageInfo,
        string packageInfoFile,
        string package,
        CancellationToken token)
    {
        try
        {
            await CreateManifest(packageInfo, packageInfoFile, token);
            ZipFile.CreateFromDirectory(source, package);
        }
        finally
        {
            // clean up
            File.Delete(packageInfoFile);
        }
    }

    /// <summary>
    /// Creates a JSON file with package packageInfo information.
    /// </summary>
    /// <param name="packageInfo">The package packageInfo information.</param>
    /// <param name="jsonFile">The path t json file with packageInfo information.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    private async Task CreateManifest(PackageInfo packageInfo, string jsonFile, CancellationToken cancellationToken)
    {
        var json = JsonSerializer.Serialize(packageInfo, JsonSerializerOptions);
        await File.WriteAllTextAsync(jsonFile, json, cancellationToken);
    }
}