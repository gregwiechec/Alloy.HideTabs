using System;
using System.Linq;
using EPiServer.Shell.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Alloy.HideTabs
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlloyHideTabs(this IServiceCollection services)
        {
            services.Configure<ProtectedModuleOptions>(
                pm =>
                {
                    if (!pm.Items.Any(i =>
                        i.Name.Equals("alloy-hideTabs", StringComparison.OrdinalIgnoreCase)))
                    {
                        pm.Items.Add(new ModuleDetails { Name = "alloy-hideTabs", Assemblies = { typeof(AvailableLayoutElementsStore).Assembly.GetName().Name }  });
                    }
                });
            return services;
        }
    }
}
https://github.com/gregwiechec/alloy-mvc-template/compare/master...gregwiechec:hide-tabs
