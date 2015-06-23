using System;

namespace Rabbit.Extensions.Loaders
{
    /// <summary>
    /// 一个抽象的扩展装载机。
    /// </summary>
    public interface IExtensionLoader
    {
        /// <summary>
        /// 装载扩展。
        /// </summary>
        /// <param name="descriptor">扩展描述符。</param>
        /// <returns>扩展条目。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="descriptor"/> 为null。</exception>
        ExtensionEntry Load(ExtensionDescriptor descriptor);
    }
}