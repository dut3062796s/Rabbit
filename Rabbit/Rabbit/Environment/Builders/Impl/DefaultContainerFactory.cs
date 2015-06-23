using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Features.Indexed;
using Rabbit.Util.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rabbit.Environment.Builders.Impl
{
    /// <summary>
    /// 一个默认的容器工厂。
    /// </summary>
    public class DefaultContainerFactory : IContainerFactory
    {
        #region Field

        private readonly ILifetimeScope _lifetimeScope;

        #endregion Field

        #region Constructor

        public DefaultContainerFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        #endregion Constructor

        #region Implementation of IContainerFactory

        /// <summary>
        /// 创建容器。
        /// </summary>
        /// <param name="blueprintItems">蓝图项集合。</param>
        /// <returns>容器。</returns>
        public ILifetimeScope CreateContainer(IEnumerable<BlueprintItem> blueprintItems)
        {
            var dependencies = blueprintItems.NotNull("blueprintItems").ToArray();

            var intermediateScope = _lifetimeScope.BeginLifetimeScope(
                builder =>
                {
                    foreach (var item in dependencies.Where(t => typeof(IModule).IsAssignableFrom(t.Type)))
                    {
                        RegisterType(builder, item)
                            .Keyed<IModule>(item.Type)
                            .InstancePerDependency();
                    }
                });

            return intermediateScope.BeginLifetimeScope(
                "shell",
                builder =>
                {
                    var moduleIndex = intermediateScope.Resolve<IIndex<Type, IModule>>();
                    //注册Aotofac Module。
                    foreach (var item in dependencies.Where(t => typeof(IModule).IsAssignableFrom(t.Type)))
                        builder.RegisterModule(moduleIndex[item.Type]);

                    //注册 "IDependency" 接口的约束规则。
                    RegisterIDependencys(builder, dependencies);
                });
        }

        #endregion Implementation of IContainerFactory

        #region Protected Method

        /// <summary>
        /// 注册 "IDependency" 接口的约束规则。
        /// </summary>
        /// <param name="builder">容器构建者。</param>
        /// <param name="blueprintItems">蓝图项集合。</param>
        protected void RegisterIDependencys(ContainerBuilder builder, IEnumerable<BlueprintItem> blueprintItems)
        {
            var dependencies = blueprintItems;

            foreach (var item in dependencies.Where(t => typeof(IDependency).IsAssignableFrom(t.Type)))
            {
                var registration = RegisterType(builder, item)
                    .InstancePerLifetimeScope();

                foreach (var interfaceType in item.Type.GetInterfaces().Where(itf => typeof(IDependency).IsAssignableFrom(itf)))
                {
                    registration = registration.As(interfaceType);
                    if (typeof(ISingletonDependency).IsAssignableFrom(interfaceType))
                    {
                        registration = registration.InstancePerMatchingLifetimeScope("shell");
                    }
                    else if (typeof(ITransientDependency).IsAssignableFrom(interfaceType))
                    {
                        registration = registration.InstancePerDependency();
                    }
                }
            }
        }

        #endregion Protected Method

        #region Private Method

        private static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType(ContainerBuilder builder, BlueprintItem item)
        {
            return builder.RegisterType(item.Type)
                .WithProperty("Feature", item.Feature)
                .WithMetadata("Feature", item.Feature);
        }

        #endregion Private Method
    }
}