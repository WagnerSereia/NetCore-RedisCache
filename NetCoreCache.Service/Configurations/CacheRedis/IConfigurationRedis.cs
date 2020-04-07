using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCache.Configurations.CacheRedis
{
    public interface IConfigurationRedis
    {
        ConfigurationRedis getConfiguration();
    }
}
