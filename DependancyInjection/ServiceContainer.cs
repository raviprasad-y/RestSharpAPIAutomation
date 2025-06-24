using Microsoft.Extensions.DependencyInjection;
using RestSharpAPIAutomation.Core;
using RestSharpAPIAutomation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.DependancyInjection
{
    public static class ServiceContainer
    {
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ApiClient>();
            services.AddTransient<PlaceServices>();

            return services.BuildServiceProvider();
        }
    }
}
