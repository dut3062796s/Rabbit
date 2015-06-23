﻿namespace Rabbit
{
    /// <summary>
    /// 表示实现者是一个基础依赖。
    /// </summary>
    public interface IDependency
    {
    }

    /// <summary>
    /// 表示实现者是一个单列依赖。
    /// </summary>
    public interface ISingletonDependency : IDependency
    {
    }

    /// <summary>
    /// 表示实现者是一个瞬态依赖。
    /// </summary>
    public interface ITransientDependency : IDependency
    {
    }
}