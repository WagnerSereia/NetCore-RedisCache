using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCache.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "NetCoreCache API",
                    Description = "API para demonstrar o uso de Cache",
                    TermsOfService = "Para uso exclusivo de estudo",
                    Contact = new Contact { Name = "Wagner Sereia", Email = "wsinfo@msn.com", Url = "https://github.com/WagnerSereia" },
                    License = new License { Name = "MIT", Url = "https://github.com/WagnerSereia" }
                });
            });
        }
    }
}
