using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Spm.Core.Abstraction;
using Spm.Core.Validators;

namespace Spm.Core;

public static class Ioc
{
    public static IServiceCollection AddPackageInfoValidator(this IServiceCollection services)
    {
        services.AddTransient<IValidator<PackageId>, PackageIdValidator>();
        services.AddTransient<IPackageInfoValidator, PackageInfoValidator>();
        return services;
    }
}