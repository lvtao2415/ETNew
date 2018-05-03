﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ET.Core.Infrastructure.Modules
{
    public interface IModuleInitializer
    {   
        /// <summary>
        /// 服务注册
        /// </summary>
        IEnumerable<KeyValuePair<int, Action<IServiceCollection>>> ConfigureServicesActionsByPriorities { get; }
        /// <summary>
        /// 配置构建
        /// </summary>
        IEnumerable<KeyValuePair<int, Action<IApplicationBuilder>>> ConfigureActionsByPriorities { get; }

        void SetServiceProvider(IServiceProvider serviceProvider);

        void SetConfigurationRoot(IConfigurationRoot configurationRoot);

        /// <summary>
        /// 添加模块MVC配置
        /// </summary>
        IEnumerable<KeyValuePair<int, Action<IMvcBuilder>>> AddMvcActionsByPriorities { get; }
        /// <summary>
        /// 自定义模块路由
        /// </summary>
        IEnumerable<KeyValuePair<int, Action<IRouteBuilder>>> UseMvcActionsByPriorities { get; }

    }
}
