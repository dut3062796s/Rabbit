using Autofac;
using Rabbit.Caching;
using Rabbit.Caching.Impl;
using Rabbit.Environment;
using Rabbit.Environment.Builders;
using Rabbit.Environment.Builders.Impl;
using Rabbit.Environment.Impl;
using Rabbit.Extensions;
using Rabbit.Extensions.Impl;
using Rabbit.FileSystems.AppData;
using Rabbit.FileSystems.AppData.Impl;
using Rabbit.FileSystems.Application;
using Rabbit.FileSystems.Application.Impl;
using Rabbit.FileSystems.VirtualPath;
using Rabbit.FileSystems.VirtualPath.Impl;
using System;
using System.Collections.Generic;
using System.Web.Hosting;

namespace Rabbit
{
    public class Starter
    {
        private readonly IList<Action<ContainerBuilder>> _builderActions = new List<Action<ContainerBuilder>>();

        /// <summary>
        /// 注册容器构建者。
        /// </summary>
        /// <param name="builderAction">容器构建动作。</param>
        public Starter RegisterBuilder(Action<ContainerBuilder> builderAction)
        {
            _builderActions.Add(builderAction);

            return this;
        }

        public ILifetimeScope GetRootContainer()
        {
            var builder = new ContainerBuilder();

            if (HostingEnvironment.IsHosted)
            {
                builder.RegisterType<WebHostEnvironment>().As<IHostEnvironment>().SingleInstance();
            }
            else
            {
                builder.RegisterType<DefaultHostEnvironment>().As<IHostEnvironment>().SingleInstance();
            }

            //Caching
            {
                builder.RegisterType<DefaultCacheHolder>().As<ICacheHolder>().SingleInstance();
                builder.RegisterType<DefaultCacheContextAccessor>().As<ICacheContextAccessor>().SingleInstance();
                builder.RegisterType<DefaultParallelCacheContext>().As<IParallelCacheContext>().SingleInstance();
                builder.RegisterType<DefaultAsyncTokenProvider>().As<IAsyncTokenProvider>().SingleInstance();
            }

            //Extensions
            {
                builder.RegisterType<DefaultContainerFactory>().As<IContainerFactory>().SingleInstance();
                builder.RegisterType<ExtensionManager>().As<IExtensionManager>().SingleInstance();
            }

            //FileSystems
            {
                //VirtualPath
                {
                    builder.RegisterType<DefaultVirtualPathMonitor>().As<IVirtualPathMonitor>().SingleInstance();
                    builder.RegisterType<DefaultVirtualPathProvider>().As<IVirtualPathProvider>().SingleInstance();
                }

                //Folders
                {
                    builder.RegisterType<DefaultAppDataFolder>().As<IAppDataFolder>().SingleInstance();
                    builder.RegisterType<DefaultApplicationFolder>().As<IApplicationFolder>().SingleInstance();
                }
            }

            foreach (var builderAction in _builderActions)
                builderAction(builder);

            return builder.Build();
        }
    }
}