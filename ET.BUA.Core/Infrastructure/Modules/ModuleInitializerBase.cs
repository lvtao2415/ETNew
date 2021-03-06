﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace ET.Core.Infrastructure.Modules
{
    public abstract class ModuleInitializerBase : IModuleInitializer
    {
        protected IHostingEnvironment hostingEnvironment;
        protected IServiceProvider serviceProvider;
        protected IConfigurationRoot configurationRoot;
        protected ILogger<ModuleInitializerBase> logger;

        public virtual IEnumerable<KeyValuePair<int, Action<IServiceCollection>>> ConfigureServicesActionsByPriorities
        {
            get
            {
                return null;
            }
        }

        public virtual IEnumerable<KeyValuePair<int, Action<IApplicationBuilder>>> ConfigureActionsByPriorities
        {
            get
            {
                return null;
            }
        }

        public virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.hostingEnvironment = serviceProvider.GetService<IHostingEnvironment>();
            this.logger = this.serviceProvider.GetService<ILoggerFactory>().CreateLogger<ModuleInitializerBase>();
        }

        public virtual void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public virtual IEnumerable<KeyValuePair<int, Action<IMvcBuilder>>> AddMvcActionsByPriorities
        {
            get
            {
                return null;
              
            }

        }

        public virtual IEnumerable<KeyValuePair<int, Action<IRouteBuilder>>> UseMvcActionsByPriorities
        {
            get
            {
                return null;
                //return new Dictionary<int, Action<IRouteBuilder>>()
                //{
                //    [2000] = routeBuilder =>
                //    {
                //        routeBuilder.MapRoute(name: "Extension B", template: "extension-b", defaults: new { controller = "ExtensionB", action = "Index" });
                //    }
                //};
            }
        }

    }
}
