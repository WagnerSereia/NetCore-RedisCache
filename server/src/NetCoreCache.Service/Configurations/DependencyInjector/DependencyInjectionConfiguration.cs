using Microsoft.Extensions.DependencyInjection;
using NetCoreCache.Domain.IoC;

namespace NetCoreCache.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}