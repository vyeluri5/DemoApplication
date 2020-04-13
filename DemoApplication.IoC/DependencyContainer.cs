using DemoApplication.Application;
using DemoApplication.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoApplication.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();

            services.AddTransient<IMyInterface, MyInterface>();

        }
    }
}
