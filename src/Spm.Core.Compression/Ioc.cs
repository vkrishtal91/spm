using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Spm.Core.Abstraction;
using Spm.Core.Compression.Abstraction;
using Spm.Core.Compression.Configurations;
using Spm.Core.Compression.Validators;

namespace Spm.Core.Compression;

public static class Ioc
{
    /// <summary>
    /// Registers SPM package compressor to your IoC.
    /// </summary>
    /// <param name="services">The IoC builder.</param>
    /// <param name="configurations">The compressor configurations.</param>
    /// <returns>The Ioc builder.</returns>
    public static IServiceCollection AddCompressor(
        this IServiceCollection services,
        Action<CompressionConfigurations> configurations = null)
    {
        return services
               .RegisterOptions(configurations)
               .RegisterValidators()
               .RegisterCompressor()
               .RegisterDecompressor()
               .RegisterHashCalculator();
    }

    private static IServiceCollection RegisterOptions(this IServiceCollection services, Action<CompressionConfigurations> configurations)
    {
        return services.Configure(configurations ?? (_ =>
        {
            var @default = new CompressionConfigurations();
            _.CompressionAlgorithm = @default.CompressionAlgorithm;
            _.CompressionLevel = @default.CompressionLevel;
            _.HashAlgorithm = @default.HashAlgorithm;
        }));
    }

    private static IServiceCollection RegisterValidators(this IServiceCollection services)
    {
        return services
               .AddPackageInfoValidator()
               .AddTransient<IValidator<CompressionConfigurations>, CompressionConfigurationsValidator>();
    }

    private static IServiceCollection RegisterCompressor(this IServiceCollection services)
    {
        // this way allows to create lazy validation and selection of implementation 
        return services.AddTransient<IPackageCompressor>(provider =>
        {
            // get and validate configurations
            var configs = provider.GetRequiredService<IOptions<CompressionConfigurations>>();
            provider.GetRequiredService<IValidator<CompressionConfigurations>>().ValidateAndThrow(configs.Value);

            // register compressor by configurations
            if (configs.Value.CompressionAlgorithm == CompressionAlgorithm.Zip)
            {
                return new PackageZipCompressor(
                    provider.GetRequiredService<IPackageInfoValidator>(),
                    configs
                );
            }

            throw new NotSupportedException("The specified compression algorithm is not supported yet.");
        });
    }

    private static IServiceCollection RegisterDecompressor(this IServiceCollection services)
    {
        // this way allows to create lazy validation and selection of implementation 
        return services.AddTransient<IPackageDecompressor>(provider =>
        {
            // get and validate configurations
            var configs = provider.GetRequiredService<IOptions<CompressionConfigurations>>();
            provider.GetRequiredService<IValidator<CompressionConfigurations>>().ValidateAndThrow(configs.Value);

            // register compressor by configurations
            if (configs.Value.CompressionAlgorithm == CompressionAlgorithm.Zip)
            {
                return new PackageZipDecompressor();
            }

            throw new NotSupportedException("The specified compression algorithm is not supported yet.");
        });
    }

    private static IServiceCollection RegisterHashCalculator(this IServiceCollection services)
    {
        // this way allows to create lazy validation and selection of implementation
        return services.AddTransient<IHashCalculator>(provider =>
        {
            // get and validate configurations
            var configs = provider.GetRequiredService<IOptions<CompressionConfigurations>>();
            provider.GetRequiredService<IValidator<CompressionConfigurations>>().ValidateAndThrow(configs.Value);

            if (configs.Value.HashAlgorithm == HashAlgorithm.Md5)
            {
                return new PackageMd5Calculator();
            }

            throw new NotSupportedException("The specified hash algorithm is not supported yet.");
        });
    }
}
