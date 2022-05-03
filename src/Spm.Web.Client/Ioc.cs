using Microsoft.Extensions.DependencyInjection;

namespace Spm.Web.Client;

public static class Ioc
{
    public static IServiceCollection AddSpmClient(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Ioc).Assembly);
        return services;
    }
}