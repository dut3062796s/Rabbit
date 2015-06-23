using Autofac;
using System.Collections.Generic;

namespace Rabbit.Environment.Builders
{
    /// <summary>
    /// 一个抽象的容器工厂。
    /// </summary>
    public interface IContainerFactory
    {
        /// <summary>
        /// 创建容器。
        /// </summary>
        /// <param name="blueprintItems">蓝图项集合。</param>
        /// <returns>容器。</returns>
        ILifetimeScope CreateContainer(IEnumerable<BlueprintItem> blueprintItems);
    }
}