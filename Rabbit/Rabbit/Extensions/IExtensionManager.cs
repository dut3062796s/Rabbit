using System.Collections.Generic;

namespace Rabbit.Extensions
{
    /// <summary>
    /// 一个抽象的扩展管理者。
    /// </summary>
    public interface IExtensionManager
    {
        /// <summary>
        /// 可用的扩展。
        /// </summary>
        /// <returns>扩展描述符条目集合。</returns>
        IEnumerable<ExtensionDescriptor> AvailableExtensions();

        /// <summary>
        /// 可用的特性。
        /// </summary>
        /// <returns>特性描述符集合。</returns>
        IEnumerable<FeatureDescriptor> AvailableFeatures();

        /// <summary>
        /// 根据扩展Id获取指定的扩展描述符条目。
        /// </summary>
        /// <param name="id">扩展Id。</param>
        /// <returns>扩展描述符。</returns>
        ExtensionDescriptor GetExtension(string id);

        /// <summary>
        /// 加载特性。
        /// </summary>
        /// <param name="featureDescriptors">特性描述符。</param>
        /// <returns>特性集合。</returns>
        IEnumerable<Feature> LoadFeatures(IEnumerable<FeatureDescriptor> featureDescriptors);
    }
}