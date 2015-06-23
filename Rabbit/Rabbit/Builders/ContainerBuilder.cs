using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rabbit.Builders
{
    /// <summary>
    /// 一个容器构建者。
    /// </summary>
    public class ContainerBuilder
    {
        #region Field

        private readonly IDictionary<string, Action<Autofac.ContainerBuilder>> _builderActions = new Dictionary<string, Action<Autofac.ContainerBuilder>>();

        #endregion Field

        /// <summary>
        /// 注册容器构建者。
        /// </summary>
        /// <param name="builderAction">容器构建动作。</param>
        public ContainerBuilder RegisterBuilder(Action<Autofac.ContainerBuilder> builderAction)
        {
            return RegisterBuilder(Guid.NewGuid().ToString("n"), builderAction);
        }

        /// <summary>
        /// 注册容器构建者。
        /// </summary>
        /// <param name="id">构建动作的标识。</param>
        /// <param name="builderAction">容器构建动作。</param>
        public ContainerBuilder RegisterBuilder(string id, Action<Autofac.ContainerBuilder> builderAction)
        {
            _builderActions[id] = builderAction;

            return this;
        }

        /// <summary>
        /// 构建容器。
        /// </summary>
        /// <returns>容器。</returns>
        public IContainer Build()
        {
            var containerBuilder = new Autofac.ContainerBuilder();
            foreach (var builderAction in _builderActions.Select(i => i.Value))
            {
                builderAction(containerBuilder);
            }

            return containerBuilder.Build();
        }
    }
}